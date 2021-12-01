using Ateliex.Areas.Cadastro.Models;
using Ateliex.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Ateliex.Areas.Cadastro.Controllers
{
    [Area("Cadastro")]
    public class ModeloRecursosController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ModeloRecursosController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: Cadastro/ModeloRecursos
        public async Task<IActionResult> Index()
        {
            var modeloRecursos = _db.ModeloRecursos
                .Include(r => r.Modelo)
                .Include(r => r.Tipo);

            return View(await modeloRecursos.ToListAsync());
        }

        // GET: Cadastro/ModeloRecursos/Detalhar/5
        public async Task<IActionResult> Detalhar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modeloRecurso = await _db.ModeloRecursos
                .Include(r => r.Modelo)
                .Include(r => r.Tipo)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (modeloRecurso == null)
            {
                return NotFound();
            }

            return View(modeloRecurso);
        }

        // GET: Cadastro/ModeloRecursos/Criar
        public IActionResult Criar()
        {
            var modeloRecurso = new ModeloRecurso();

            ViewData["ModeloId"] = new SelectList(_db.Modelos, "Id", "Nome");

            ViewData["TipoId"] = new SelectList(_db.ModeloRecursoTipos, "Id", "Nome");

            return View(modeloRecurso);
        }

        // POST: Cadastro/ModeloRecursos/Criar
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar([Bind("ModeloId,TipoId,Descricao,Custo,Unidades,Id")] ModeloRecurso modeloRecurso)
        {
            if (ModelState.IsValid)
            {
                _db.Add(modeloRecurso);

                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            ViewData["ModeloId"] = new SelectList(_db.Modelos, "Id", "Nome", modeloRecurso.ModeloId);

            ViewData["TipoId"] = new SelectList(_db.ModeloRecursoTipos, "Id", "Nome", modeloRecurso.TipoId);

            return View(modeloRecurso);
        }

        // GET: Cadastro/ModeloRecursos/Editar/5
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modeloRecurso = await _db.ModeloRecursos.FindAsync(id);

            if (modeloRecurso == null)
            {
                return NotFound();
            }

            ViewData["ModeloId"] = new SelectList(_db.Modelos, "Id", "Nome", modeloRecurso.ModeloId);

            ViewData["TipoId"] = new SelectList(_db.ModeloRecursoTipos, "Id", "Nome", modeloRecurso.TipoId);

            return View(modeloRecurso);
        }

        // POST: Cadastro/ModeloRecursos/Editar/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("ModeloId,TipoId,Descricao,Custo,Unidades,Id")] ModeloRecurso modeloRecurso)
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

            ViewData["ModeloId"] = new SelectList(_db.Modelos, "Id", "Nome", modeloRecurso.ModeloId);

            ViewData["TipoId"] = new SelectList(_db.ModeloRecursoTipos, "Id", "Nome", modeloRecurso.TipoId);

            return View(modeloRecurso);
        }

        // GET: Cadastro/ModeloRecursos/Excluir/5
        public async Task<IActionResult> Excluir(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modeloRecurso = await _db.ModeloRecursos
                .Include(r => r.Modelo)
                .Include(r => r.Tipo)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (modeloRecurso == null)
            {
                return NotFound();
            }

            return View(modeloRecurso);
        }

        // POST: Cadastro/ModeloRecursos/Excluir/5
        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmarExclusao(int id)
        {
            var modeloRecurso = await _db.ModeloRecursos.FindAsync(id);

            _db.ModeloRecursos.Remove(modeloRecurso);

            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool RecursoModeloExists(int id)
        {
            return _db.ModeloRecursos.Any(e => e.Id == id);
        }
    }
}
