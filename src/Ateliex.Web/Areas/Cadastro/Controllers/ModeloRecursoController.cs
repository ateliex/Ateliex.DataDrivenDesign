using Ateliex.Areas.Cadastro.Models;
using Ateliex.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Ateliex.Areas.Cadastro.Controllers
{
    [Area("Cadastro")]
    public class ModeloRecursoController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ModeloRecursoController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: Cadastro/ModeloRecurso
        public async Task<IActionResult> Index()
        {
            var modeloRecursoQuery = _db.ModeloRecursoSet
                .Include(r => r.Modelo)
                .Include(r => r.Tipo);

            return View(await modeloRecursoQuery.ToListAsync());
        }

        // GET: Cadastro/ModeloRecurso/Detalhar/5
        public async Task<IActionResult> Detalhar(int? id, [FromQuery] int? modeloId)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modeloRecurso = await _db.ModeloRecursoSet
                .Include(r => r.Modelo)
                .ThenInclude(m => m.Recursos)
                .Include(r => r.Observacao)
                .Include(r => r.Tipo)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (modeloRecurso == null)
            {
                return NotFound();
            }

            if (modeloId.HasValue)
            {
                ViewData["modeloId"] = modeloId;
            }

            return View(modeloRecurso);
        }

        // GET: Cadastro/ModeloRecurso/Criar
        public IActionResult Criar([FromQuery] int? modeloId)
        {
            var modeloRecurso = new ModeloRecurso();

            ViewData["ModeloId"] = new SelectList(_db.ModeloSet, "Id", "Nome");

            ViewData["TipoId"] = new SelectList(_db.ModeloRecursoTipoSet, "Id", "Nome");

            if (modeloId.HasValue)
            {
                modeloRecurso.ModeloId = modeloId.Value;
            }

            if (modeloId.HasValue)
            {
                ViewData["modeloId"] = modeloId;
            }

            return View(modeloRecurso);
        }

        // POST: Cadastro/ModeloRecurso/Criar
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar([Bind("ModeloId,TipoId,Descricao,Custo,Unidades,Id")] ModeloRecurso modeloRecurso, [FromQuery] int? modeloId)
        {
            if (ModelState.IsValid)
            {
                _db.Add(modeloRecurso);

                await _db.SaveChangesAsync();

                if (modeloId.HasValue)
                {
                    return RedirectToAction("Detalhar", "Modelo", new { id = modeloId.Value });
                }

                return RedirectToAction(nameof(Index));
            }

            ViewData["ModeloId"] = new SelectList(_db.ModeloSet, "Id", "Nome", modeloRecurso.ModeloId);

            ViewData["TipoId"] = new SelectList(_db.ModeloRecursoTipoSet, "Id", "Nome", modeloRecurso.TipoId);

            if (modeloId.HasValue)
            {
                ViewData["modeloId"] = modeloId;
            }

            return View(modeloRecurso);
        }

        // GET: Cadastro/ModeloRecurso/Editar/5
        public async Task<IActionResult> Editar(int? id, [FromQuery] int? modeloId)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modeloRecurso = await _db.ModeloRecursoSet.FindAsync(id);

            if (modeloRecurso == null)
            {
                return NotFound();
            }

            ViewData["ModeloId"] = new SelectList(_db.ModeloSet, "Id", "Nome", modeloRecurso.ModeloId);

            ViewData["TipoId"] = new SelectList(_db.ModeloRecursoTipoSet, "Id", "Nome", modeloRecurso.TipoId);

            if (modeloId.HasValue)
            {
                ViewData["modeloId"] = modeloId;
            }

            return View(modeloRecurso);
        }

        // POST: Cadastro/ModeloRecurso/Editar/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("ModeloId,TipoId,Descricao,Custo,Unidades,Id")] ModeloRecurso modeloRecurso, [FromQuery] int? modeloId)
        {
            if (id != modeloRecurso.Id)
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
                    if (!RecursoModeloExists(modeloRecurso.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            ViewData["ModeloId"] = new SelectList(_db.ModeloSet, "Id", "Nome", modeloRecurso.ModeloId);

            ViewData["TipoId"] = new SelectList(_db.ModeloRecursoTipoSet, "Id", "Nome", modeloRecurso.TipoId);

            if (modeloId.HasValue)
            {
                ViewData["modeloId"] = modeloId;
            }

            return View(modeloRecurso);
        }

        // GET: Cadastro/ModeloRecurso/Excluir/5
        public async Task<IActionResult> Excluir(int? id, [FromQuery] int? modeloId)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modeloRecurso = await _db.ModeloRecursoSet
                .Include(r => r.Modelo)
                .Include(r => r.Tipo)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (modeloRecurso == null)
            {
                return NotFound();
            }

            if (modeloId.HasValue)
            {
                ViewData["modeloId"] = modeloId;
            }

            return View(modeloRecurso);
        }

        // POST: Cadastro/ModeloRecurso/Excluir/5
        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmarExclusao(int id)
        {
            var modeloRecurso = await _db.ModeloRecursoSet.FindAsync(id);

            _db.ModeloRecursoSet.Remove(modeloRecurso);

            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool RecursoModeloExists(int id)
        {
            return _db.ModeloRecursoSet.Any(e => e.Id == id);
        }
    }
}
