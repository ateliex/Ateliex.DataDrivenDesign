#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ateliex.Areas.Cadastro.Models;
using Ateliex.Data;

namespace Ateliex.Areas.Cadastro.Controllers
{
    [Area("Cadastro")]
    public class ModeloRecursoTipoDescricaoController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ModeloRecursoTipoDescricaoController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: Cadastro/ModeloRecursoTipoDescricao
        public async Task<IActionResult> Index()
        {
            var modeloRecursoTipoDesricaoQuery = _db.ModeloRecursoTipoDesricaoSet
                .Include(m => m.Tipo);
            
            return View(await modeloRecursoTipoDesricaoQuery.ToListAsync());
        }

        // GET: Cadastro/ModeloRecursoTipoDescricao/Detalhar/5
        public async Task<IActionResult> Detalhar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modeloRecursoTipoDescricao = await _db.ModeloRecursoTipoDesricaoSet
                .Include(m => m.Tipo)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (modeloRecursoTipoDescricao == null)
            {
                return NotFound();
            }

            return View(modeloRecursoTipoDescricao);
        }

        // GET: Cadastro/ModeloRecursoTipoDescricao/Criar
        public IActionResult Criar()
        {
            ViewData["TipoId"] = new SelectList(_db.ModeloRecursoTipoSet, "Id", "Nome");

            return View();
        }

        // POST: Cadastro/ModeloRecursoTipoDescricao/Criar
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar([Bind("TipoId,Texto,Id")] ModeloRecursoTipoDescricao modeloRecursoTipoDescricao)
        {
            if (ModelState.IsValid)
            {
                _db.Add(modeloRecursoTipoDescricao);

                await _db.SaveChangesAsync();
                
                return RedirectToAction(nameof(Index));
            }

            ViewData["TipoId"] = new SelectList(_db.ModeloRecursoTipoSet, "Id", "Nome", modeloRecursoTipoDescricao.TipoId);
            
            return View(modeloRecursoTipoDescricao);
        }

        // GET: Cadastro/ModeloRecursoTipoDescricao/Editar/5
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modeloRecursoTipoDescricao = await _db.ModeloRecursoTipoDesricaoSet.FindAsync(id);

            if (modeloRecursoTipoDescricao == null)
            {
                return NotFound();
            }
            
            ViewData["TipoId"] = new SelectList(_db.ModeloRecursoTipoSet, "Id", "Nome", modeloRecursoTipoDescricao.TipoId);
            
            return View(modeloRecursoTipoDescricao);
        }

        // POST: Cadastro/ModeloRecursoTipoDescricao/Editar/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("TipoId,Texto,Id")] ModeloRecursoTipoDescricao modeloRecursoTipoDescricao)
        {
            if (id != modeloRecursoTipoDescricao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(modeloRecursoTipoDescricao);

                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModeloRecursoTipoDescricaoExists(modeloRecursoTipoDescricao.Id))
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
            
            ViewData["TipoId"] = new SelectList(_db.ModeloRecursoTipoSet, "Id", "Nome", modeloRecursoTipoDescricao.TipoId);
            
            return View(modeloRecursoTipoDescricao);
        }

        // GET: Cadastro/ModeloRecursoTipoDescricao/Excluir/5
        public async Task<IActionResult> Excluir(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modeloRecursoTipoDescricao = await _db.ModeloRecursoTipoDesricaoSet
                .Include(m => m.Tipo)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (modeloRecursoTipoDescricao == null)
            {
                return NotFound();
            }

            return View(modeloRecursoTipoDescricao);
        }

        // POST: Cadastro/ModeloRecursoTipoDescricao/Excluir/5
        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmarExclusao(int id)
        {
            var modeloRecursoTipoDescricao = await _db.ModeloRecursoTipoDesricaoSet.FindAsync(id);

            _db.ModeloRecursoTipoDesricaoSet.Remove(modeloRecursoTipoDescricao);
            
            await _db.SaveChangesAsync();
            
            return RedirectToAction(nameof(Index));
        }

        private bool ModeloRecursoTipoDescricaoExists(int id)
        {
            return _db.ModeloRecursoTipoDesricaoSet.Any(e => e.Id == id);
        }
    }
}
