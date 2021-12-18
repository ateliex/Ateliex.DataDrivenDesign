using Ateliex.Areas.Cadastro.Models;
using Ateliex.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Ateliex.Areas.Cadastro.Controllers
{
    [Area("Cadastro")]
    public class ModeloRecursoAnexoController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ModeloRecursoAnexoController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: Cadastro/ModeloRecursoAnexo
        public async Task<IActionResult> Index()
        {
            var modeloRecursoAnexoQuery = _db.ModeloRecursoAnexoSet
                .Include(a => a.Recurso)
                .ThenInclude(r => r.Modelo);

            return View(await modeloRecursoAnexoQuery.ToListAsync());
        }

        // GET: Cadastro/ModeloRecursoAnexo/Detalhar/5
        public async Task<IActionResult> Detalhar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modeloRecursoAnexo = await _db.ModeloRecursoAnexoSet
                .Include(a => a.Recurso)
                .ThenInclude(r => r.Modelo)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (modeloRecursoAnexo == null)
            {
                return NotFound();
            }

            return View(modeloRecursoAnexo);
        }

        // GET: Cadastro/ModeloRecursoAnexo/Criar
        public IActionResult Criar()
        {
            var modeloRecursoAnexo = new ModeloRecursoAnexo();

            ViewData["RecursoId"] = new SelectList(_db.ModeloRecursoSet, "Id", "Descricao");
            
            return View(modeloRecursoAnexo);
        }

        // POST: Cadastro/ModeloRecursoAnexo/Criar
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar([Bind("RecursoId,Nome,Arquivo,Id")] ModeloRecursoAnexo modeloRecursoAnexo)
        {
            if (ModelState.IsValid)
            {
                _db.Add(modeloRecursoAnexo);

                await _db.SaveChangesAsync();
                
                return RedirectToAction(nameof(Index));
            }

            ViewData["RecursoId"] = new SelectList(_db.ModeloRecursoSet, "Id", "Descricao", modeloRecursoAnexo.RecursoId);
            
            return View(modeloRecursoAnexo);
        }

        // GET: Cadastro/ModeloRecursoAnexo/Editar/5
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modeloRecursoAnexo = await _db.ModeloRecursoAnexoSet.FindAsync(id);

            if (modeloRecursoAnexo == null)
            {
                return NotFound();
            }

            ViewData["RecursoId"] = new SelectList(_db.ModeloRecursoSet, "Id", "Descricao", modeloRecursoAnexo.RecursoId);
            
            return View(modeloRecursoAnexo);
        }

        // POST: Cadastro/ModeloRecursoAnexo/Editar/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("RecursoId,Nome,Arquivo,Id")] ModeloRecursoAnexo modeloRecursoAnexo)
        {
            if (id != modeloRecursoAnexo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(modeloRecursoAnexo);

                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModeloRecursoAnexoExists(modeloRecursoAnexo.Id))
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

            ViewData["RecursoId"] = new SelectList(_db.ModeloRecursoSet, "Id", "Descricao", modeloRecursoAnexo.RecursoId);

            return View(modeloRecursoAnexo);
        }

        // GET: Cadastro/ModeloRecursoAnexo/Excluir/5
        public async Task<IActionResult> Excluir(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modeloRecursoAnexo = await _db.ModeloRecursoAnexoSet
                .Include(a => a.Recurso)
                .ThenInclude(r => r.Modelo)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (modeloRecursoAnexo == null)
            {
                return NotFound();
            }

            return View(modeloRecursoAnexo);
        }

        // POST: Cadastro/ModeloRecursoAnexo/Excluir/5
        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmarExclusao(int id)
        {
            var modeloRecursoAnexo = await _db.ModeloRecursoAnexoSet.FindAsync(id);

            _db.ModeloRecursoAnexoSet.Remove(modeloRecursoAnexo);
            
            await _db.SaveChangesAsync();
            
            return RedirectToAction(nameof(Index));
        }

        private bool ModeloRecursoAnexoExists(int id)
        {
            return _db.ModeloRecursoAnexoSet.Any(e => e.Id == id);
        }
    }
}
