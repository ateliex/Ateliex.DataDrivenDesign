using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ateliex.Areas.Cadastro.Models;
using Ateliex.Data;
using Ateliex.Extensions;
using Ateliex.Areas.Cadastro.Services;

namespace Ateliex.Areas.Cadastro.Controllers
{
    [Area("Cadastro")]
    //[Route("{controller}")]
    public class ModeloController : Controller
    {
        private readonly ModeloService _modeloService;

        public ModeloController(ModeloService modeloService)
        {
            _modeloService = modeloService;
        }

        // GET: Cadastro/Modelo
        public async Task<IActionResult> Index()
        {
            return View(await _modeloService.ObterListaModelo());
        }

        // GET: Cadastro/Modelo/Detalhar/5
        public async Task<IActionResult> Detalhar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Modelo modelo = await _modeloService.ObterModeloDetalhado(id);

            if (modelo == null)
            {
                return NotFound();
            }

            return View(modelo);
        }

        // GET: Cadastro/Modelo/Criar
        public IActionResult Criar()
        {
            var modelo = new Modelo();

            return View(modelo);
        }

        // POST: Cadastro/Modelo/Criar
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar([Bind("Id,Nome,State")] Modelo modelo)
        {
            if (ModelState.IsValid)
            {
                await _modeloService.Adicionar(modelo);

                return RedirectToAction(nameof(Index));
            }
            return View(modelo);
        }

        // GET: Cadastro/Modelo/Editar/5
        public async Task<IActionResult> Editar(int? id)
        {
            Modelo modelo;

            if (id == null)
            {
                return NotFound();
            }
            else
            {
                modelo = await _modeloService.ObterModelo(id);

                if (modelo == null)
                {
                    return NotFound();
                }
            }

            return View(modelo);
        }

        // POST: Cadastro/Modelo/Editar/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int? id, [Bind("Id,Nome,State")] Modelo modelo)
        {
            if (id != modelo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (id == null)
                    {
                        await _modeloService.Adicionar(modelo);

                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        await _modeloService.Atualizar(modelo);
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_modeloService.ModeloExists(modelo.Id))
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
            return View(modelo);
        }

        // GET: Cadastro/Modelo/Excluir/5
        public async Task<IActionResult> Excluir(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Modelo modelo = await _modeloService.ObterModeloDetalhado(id);

            if (modelo == null)
            {
                return NotFound();
            }

            return View(modelo);
        }

        // POST: Cadastro/Modelo/Excluir/5
        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmarExclusao(int id)
        {
            Modelo modelo = await _modeloService.ObterModelo(id);

            await _modeloService.Excluir(modelo);

            return RedirectToAction(nameof(Index));
        }
    }
}
