using Ateliex.Areas.Cadastro.Models;
using Ateliex.Areas.Cadastro.Services;
using Ateliex.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Ateliex.Areas.Cadastro.Controllers
{
    [Area("Cadastro")]
    public class ModeloRecursoTipoController : Controller
    {
        private readonly AteliexDbContext _db;

        public ModeloRecursoTipoController(AteliexDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _db.GetModeloRecursoTipoAll();

            return View(list);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modeloRecursoTipo = await _db.GetModeloRecursoTipo(id.Value);

            if (modeloRecursoTipo == null)
            {
                return NotFound();
            }

            return View(modeloRecursoTipo);
        }

        public IActionResult Create()
        {
            var modeloRecursoTipo = new ModeloRecursoTipo();

            return View(modeloRecursoTipo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] ModeloRecursoTipo modeloRecursoTipo)
        {
            if (ModelState.IsValid)
            {
                _db.Add(modeloRecursoTipo);

                await _db.SaveChangesAsync();
                
                return RedirectToAction(nameof(Index));
            }

            return View(modeloRecursoTipo);
        }

        public async Task<IActionResult> Edit(int? id, string? from)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modeloRecursoTipo = await _db.ModeloRecursoTipoSet.FindAsync(id);

            if (modeloRecursoTipo == null)
            {
                return NotFound();
            }

            ViewData["From"] = from;

            return View(modeloRecursoTipo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,RowVersion")] ModeloRecursoTipo modeloRecursoTipo, string? from)
        {
            if (id != modeloRecursoTipo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(modeloRecursoTipo);

                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModeloRecursoTipoExists(modeloRecursoTipo.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                
                if (from == "Details")
                {
                    return RedirectToAction(nameof(Details), new { id });
                }

                return RedirectToAction(nameof(Index));
            }

            ViewData["From"] = from;

            return View(modeloRecursoTipo);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modeloRecursoTipo = await _db.GetModeloRecursoTipo(id.Value);
            
            if (modeloRecursoTipo == null)
            {
                return NotFound();
            }

            return View(modeloRecursoTipo);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var modeloRecursoTipo = await _db.ModeloRecursoTipoSet.FindAsync(id);

            if (modeloRecursoTipo == null)
            {
                return NotFound();
            }

            _db.ModeloRecursoTipoSet.Remove(modeloRecursoTipo);

            try
            {
                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException is SqlException)
                {
                    var sqlException = ex.InnerException as SqlException;

                    if (sqlException.Message.Contains("FK_ModeloRecurso_ModeloRecursoTipo_TipoId"))
                    {
                        ModelState.AddModelError(ex.Message, sqlException.Message);

                        return View(modeloRecursoTipo);
                    }
                }

                throw;
            }
        }

        private bool ModeloRecursoTipoExists(int id)
        {
            return _db.ModeloRecursoTipoSet.Any(e => e.Id == id);
        }
    }
}
