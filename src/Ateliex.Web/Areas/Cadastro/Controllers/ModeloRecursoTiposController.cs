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
    public class ModeloRecursoTiposController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ModeloRecursoTiposController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: Cadastro/ModeloRecursoTipos
        public async Task<IActionResult> Index()
        {
            return View(await _db.ModeloRecursoTipos.ToListAsync());
        }

        // GET: Cadastro/ModeloRecursoTipos/Detalhar/5
        public async Task<IActionResult> Detalhar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modeloRecursoTipo = await _db.ModeloRecursoTipos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (modeloRecursoTipo == null)
            {
                return NotFound();
            }

            return View(modeloRecursoTipo);
        }

        // GET: Cadastro/ModeloRecursoTipos/Criar
        public IActionResult Criar()
        {
            var modeloRecursoTipo = new ModeloRecursoTipo();

            return View(modeloRecursoTipo);
        }

        // POST: Cadastro/ModeloRecursoTipos/Criar
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar([Bind("Nome,Id")] ModeloRecursoTipo modeloRecursoTipo)
        {
            if (ModelState.IsValid)
            {
                _db.Add(modeloRecursoTipo);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(modeloRecursoTipo);
        }

        // GET: Cadastro/ModeloRecursoTipos/Editar/5
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modeloRecursoTipo = await _db.ModeloRecursoTipos.FindAsync(id);
            if (modeloRecursoTipo == null)
            {
                return NotFound();
            }
            return View(modeloRecursoTipo);
        }

        // POST: Cadastro/ModeloRecursoTipos/Editar/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("Nome,Id")] ModeloRecursoTipo modeloRecursoTipo)
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
                return RedirectToAction(nameof(Index));
            }
            return View(modeloRecursoTipo);
        }

        // GET: Cadastro/ModeloRecursoTipos/Excluir/5
        public async Task<IActionResult> Excluir(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modeloRecursoTipo = await _db.ModeloRecursoTipos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (modeloRecursoTipo == null)
            {
                return NotFound();
            }

            return View(modeloRecursoTipo);
        }

        // POST: Cadastro/ModeloRecursoTipos/Excluir/5
        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmarExclusao(int id)
        {
            var modeloRecursoTipo = await _db.ModeloRecursoTipos.FindAsync(id);
            _db.ModeloRecursoTipos.Remove(modeloRecursoTipo);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModeloRecursoTipoExists(int id)
        {
            return _db.ModeloRecursoTipos.Any(e => e.Id == id);
        }
    }
}
