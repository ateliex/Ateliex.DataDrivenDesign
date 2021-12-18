using Ateliex.Areas.Cadastro.Models;
using Ateliex.Areas.Cadastro.Services;
using Ateliex.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Ateliex.Areas.Cadastro.Controllers
{
    [Area("Cadastro")]
    public class ModeloRecursoController : Controller
    {
        private readonly AteliexDbContext _db;

        public ModeloRecursoController(AteliexDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _db.GetModeloRecursoAll();

            return View(list);
        }

        public async Task<IActionResult> Details(int? id, string modeloCodigo)
        {
            if (id == null || modeloCodigo == null)
            {
                return NotFound();
            }

            var modeloRecurso = await _db.GetModeloRecurso(id.Value, modeloCodigo);

            if (modeloRecurso == null)
            {
                return NotFound();
            }

            return View(modeloRecurso);
        }

        public IActionResult Create(string? modeloCodigo, int? tipoId)
        {
            var modeloRecurso = new ModeloRecurso();

            ViewData["ModeloCodigo"] = new SelectList(_db.ModeloSet, "Codigo", "Nome");

            ViewData["TipoId"] = new SelectList(_db.ModeloRecursoTipoSet, "Id", "Nome");

            if (modeloCodigo != null)
            {
                modeloRecurso.ModeloCodigo = modeloCodigo;

                ViewData["Parent"] = "Modelo";
            }

            if (tipoId.HasValue)
            {
                modeloRecurso.TipoId = tipoId.Value;

                ViewData["Parent"] = "ModeloRecursoTipo";
            }

            return View(modeloRecurso);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ModeloCodigo,Id,TipoId,Descricao,Custo,Unidades")] ModeloRecurso modeloRecurso, string? parent)
        {
            if (ModelState.IsValid)
            {
                _db.Add(modeloRecurso);

                await _db.SaveChangesAsync();

                if (parent == "Modelo")
                {
                    return RedirectToAction("Details", "Modelo", new { id = modeloRecurso.ModeloCodigo });
                }

                if (parent == "ModeloRecursoTipo")
                {
                    return RedirectToAction("Details", "ModeloRecursoTipo", new { id = modeloRecurso.TipoId });
                }

                return RedirectToAction(nameof(Index));
            }

            ViewData["ModeloCodigo"] = new SelectList(_db.ModeloSet, "Codigo", "Nome", modeloRecurso.ModeloCodigo);

            ViewData["TipoId"] = new SelectList(_db.ModeloRecursoTipoSet, "Id", "Nome", modeloRecurso.TipoId);

            ViewData["Parent"] = parent;

            return View(modeloRecurso);
        }

        public async Task<IActionResult> Edit(int? id, string modeloCodigo, string? parent, string? from)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modeloRecurso = await _db.ModeloRecursoSet.FindAsync(modeloCodigo, id);

            if (modeloRecurso == null)
            {
                return NotFound();
            }

            ViewData["ModeloCodigo"] = new SelectList(_db.ModeloSet, "Codigo", "Nome", modeloRecurso.ModeloCodigo);

            ViewData["TipoId"] = new SelectList(_db.ModeloRecursoTipoSet, "Id", "Nome", modeloRecurso.TipoId);

            ViewData["Parent"] = parent;

            ViewData["From"] = from;

            return View(modeloRecurso);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, string modeloCodigo, [Bind("ModeloCodigo,Id,TipoId,Descricao,Custo,Unidades,RowVersion")] ModeloRecurso modeloRecurso, string? parent, string? from)
        {
            if (id != modeloRecurso.Id || modeloCodigo != modeloRecurso.ModeloCodigo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(modeloRecurso);

                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModeloRecursoExists(modeloRecurso.Id, modeloRecurso.ModeloCodigo))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                if (parent == "Modelo")
                {
                    return RedirectToAction("Details", "Modelo", new { id = modeloRecurso.ModeloCodigo });
                }

                if (parent == "ModeloRecursoTipo")
                {
                    return RedirectToAction("Details", "ModeloRecursoTipo", new { id = modeloRecurso.TipoId });
                }

                if (from == "Details")
                {
                    return RedirectToAction(nameof(Details), new { id, modeloCodigo });
                }

                return RedirectToAction(nameof(Index));
            }

            ViewData["ModeloCodigo"] = new SelectList(_db.ModeloSet, "Codigo", "Nome", modeloRecurso.ModeloCodigo);

            ViewData["TipoId"] = new SelectList(_db.ModeloRecursoTipoSet, "Id", "Nome", modeloRecurso.TipoId);

            ViewData["Parent"] = parent;

            ViewData["From"] = from;

            return View(modeloRecurso);
        }

        public async Task<IActionResult> Delete(int? id, string modeloCodigo, string? parent)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modeloRecurso = await _db.GetModeloRecurso(id.Value, modeloCodigo);

            if (modeloRecurso == null)
            {
                return NotFound();
            }

            ViewData["Parent"] = parent;

            return View(modeloRecurso);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, string modeloCodigo, string? parent)
        {
            var modeloRecurso = await _db.ModeloRecursoSet.FindAsync(modeloCodigo, id);

            if (modeloRecurso == null)
            {
                return NotFound();
            }

            _db.ModeloRecursoSet.Remove(modeloRecurso);

            await _db.SaveChangesAsync();

            if (parent == "Modelo")
            {
                return RedirectToAction("Details", "Modelo", new { id = modeloRecurso.ModeloCodigo });
            }

            if (parent == "ModeloRecursoTipo")
            {
                return RedirectToAction("Details", "ModeloRecursoTipo", new { id = modeloRecurso.TipoId });
            }

            return RedirectToAction(nameof(Index));
        }

        private bool ModeloRecursoExists(int id, string modeloCodigo)
        {
            return _db.ModeloRecursoSet.Any(e => e.Id == id || e.ModeloCodigo == modeloCodigo);
        }
    }
}
