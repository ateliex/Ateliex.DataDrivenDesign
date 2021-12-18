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
    public class ModeloRecursoObservacaoController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ModeloRecursoObservacaoController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: Cadastro/ModeloRecursoObservacao
        public async Task<IActionResult> Index()
        {
            var modeloRecursoObservacaoQuery = _db.ModeloRecursoObservacaoSet
                .Include(mro => mro.Recurso)
                .ThenInclude(mr => mr.Modelo);

            return View(await modeloRecursoObservacaoQuery.ToListAsync());
        }

        // GET: Cadastro/ModeloRecursoObservacao/Detalhar/5
        public async Task<IActionResult> Detalhar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modeloRecursoObservacao = await _db.ModeloRecursoObservacaoSet
                .Include(mro => mro.Recurso)
                .ThenInclude(mr => mr.Modelo)
                .FirstOrDefaultAsync(mro => mro.Id == id);

            if (modeloRecursoObservacao == null)
            {
                return NotFound();
            }

            return View(modeloRecursoObservacao);
        }

        // GET: Cadastro/ModeloRecursoObservacao/Criar
        public IActionResult Criar()
        {
            ViewData["RecursoId"] = new SelectList(_db.ModeloRecursoSet, "Id", "Descricao");

            return View();
        }

        // POST: Cadastro/ModeloRecursoObservacao/Criar
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar([Bind("RecursoId,Texto,Id")] ModeloRecursoObservacao modeloRecursoObservacao)
        {
            if (ModelState.IsValid)
            {
                _db.Add(modeloRecursoObservacao);

                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            ViewData["RecursoId"] = new SelectList(_db.ModeloRecursoSet, "Id", "Descricao", modeloRecursoObservacao.RecursoId);

            return View(modeloRecursoObservacao);
        }

        // GET: Cadastro/ModeloRecursoObservacao/Editar/5
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modeloRecursoObservacao = await _db.ModeloRecursoObservacaoSet.FindAsync(id);

            if (modeloRecursoObservacao == null)
            {
                return NotFound();
            }

            ViewData["RecursoId"] = new SelectList(_db.ModeloRecursoSet, "Id", "Descricao", modeloRecursoObservacao.RecursoId);

            return View(modeloRecursoObservacao);
        }

        // POST: Cadastro/ModeloRecursoObservacao/Editar/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("RecursoId,Texto,Id")] ModeloRecursoObservacao modeloRecursoObservacao)
        {
            if (id != modeloRecursoObservacao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(modeloRecursoObservacao);

                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModeloRecursoObservacaoExists(modeloRecursoObservacao.Id))
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

            ViewData["RecursoId"] = new SelectList(_db.ModeloRecursoSet, "Id", "Descricao", modeloRecursoObservacao.RecursoId);

            return View(modeloRecursoObservacao);
        }

        // GET: Cadastro/ModeloRecursoObservacao/Excluir/5
        public async Task<IActionResult> Excluir(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modeloRecursoObservacao = await _db.ModeloRecursoObservacaoSet
                .Include(m => m.Recurso)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (modeloRecursoObservacao == null)
            {
                return NotFound();
            }

            return View(modeloRecursoObservacao);
        }

        // POST: Cadastro/ModeloRecursoObservacao/Excluir/5
        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmarExclusao(int id)
        {
            var modeloRecursoObservacao = await _db.ModeloRecursoObservacaoSet.FindAsync(id);

            _db.ModeloRecursoObservacaoSet.Remove(modeloRecursoObservacao);

            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool ModeloRecursoObservacaoExists(int id)
        {
            return _db.ModeloRecursoObservacaoSet.Any(e => e.Id == id);
        }
    }
}
