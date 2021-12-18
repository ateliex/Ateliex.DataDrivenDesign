using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ateliex.Areas.Cadastro.Models;
using Ateliex.Data;
using Ateliex.Areas.Cadastro.Services;

namespace Ateliex.Areas.Cadastro.Controllers
{
    [Area("Cadastro")]
    public class ModeloRecursoTipoController : Controller
    {
        private readonly ModeloRecursoTipoService _modeloRecursoTipoService;

        public ModeloRecursoTipoController(ModeloRecursoTipoService modeloRecursoTipoService)
        {
            _modeloRecursoTipoService = modeloRecursoTipoService;
        }

        // GET: Cadastro/ModeloRecursoTipo
        public async Task<IActionResult> Index()
        {
            return View(await _modeloRecursoTipoService.ObterListaModeloRecursoTipo());
        }

        // GET: Cadastro/ModeloRecursoTipo/Detalhar/5
        public async Task<IActionResult> Detalhar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modeloRecursoTipo = await _modeloRecursoTipoService.ObterModeloRecursoTipoDetalhado(id);

            if (modeloRecursoTipo == null)
            {
                return NotFound();
            }

            return View(modeloRecursoTipo);
        }

        // GET: Cadastro/ModeloRecursoTipo/Criar
        public IActionResult Criar()
        {
            var modeloRecursoTipo = new ModeloRecursoTipo();

            return View(modeloRecursoTipo);
        }

        // POST: Cadastro/ModeloRecursoTipo/Criar
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar([Bind("Nome,Id")] ModeloRecursoTipo modeloRecursoTipo)
        {
            if (ModelState.IsValid)
            {
                await _modeloRecursoTipoService.Adicionar(modeloRecursoTipo);

                return RedirectToAction(nameof(Index));
            }

            return View(modeloRecursoTipo);
        }

        // GET: Cadastro/ModeloRecursoTipo/Editar/5
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modeloRecursoTipo = await _modeloRecursoTipoService.ObterModeloRecursoTipo(id);

            if (modeloRecursoTipo == null)
            {
                return NotFound();
            }

            return View(modeloRecursoTipo);
        }

        // POST: Cadastro/ModeloRecursoTipo/Editar/5
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
                    await _modeloRecursoTipoService.Atualizar(modeloRecursoTipo);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_modeloRecursoTipoService.ModeloRecursoTipoExists(modeloRecursoTipo.Id))
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

        // GET: Cadastro/ModeloRecursoTipo/Excluir/5
        public async Task<IActionResult> Excluir(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modeloRecursoTipo = await _modeloRecursoTipoService.ObterModeloRecursoTipoDetalhado(id);

            if (modeloRecursoTipo == null)
            {
                return NotFound();
            }

            return View(modeloRecursoTipo);
        }

        // POST: Cadastro/ModeloRecursoTipo/Excluir/5
        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmarExclusao(int id)
        {
            var modeloRecursoTipo = await _modeloRecursoTipoService.ObterModeloRecursoTipo(id);

            await _modeloRecursoTipoService.Excluir(modeloRecursoTipo);

            return RedirectToAction(nameof(Index));
        }
    }
}
