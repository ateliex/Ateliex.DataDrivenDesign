﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ateliex.Areas.Cadastro.Models;
using Ateliex.Data;
using Ateliex.Extensions;

namespace Ateliex.Areas.Cadastro.Controllers
{
    [Area("Cadastro")]
    //[Route("{controller}")]
    public class ModelosController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ModelosController(ApplicationDbContext context)
        {
            _db = context;
        }

        // GET: Cadastro/Modelos
        public async Task<IActionResult> Index()
        {
            return View(await _db.Modelos.ToListAsync());
        }

        // GET: Cadastro/Modelos/Detalhar/5
        public async Task<IActionResult> Detalhar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modelo = await _db.Modelos
                .Include(m => m.Recursos)
                .ThenInclude(r => r.Tipo)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (modelo == null)
            {
                return NotFound();
            }

            return View(modelo);
        }

        // GET: Cadastro/Modelos/Criar
        public IActionResult Criar()
        {
            var modelo = new Modelo();

            return View(modelo);
        }

        // POST: Cadastro/Modelos/Criar
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar([Bind("Id,Nome,State")] Modelo modelo)
        {
            if (ModelState.IsValid)
            {
                _db.Add(modelo);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(modelo);
        }

        // GET: Cadastro/Modelos/Editar/5
        public async Task<IActionResult> Editar(int? id)
        {
            Modelo modelo;

            if (id == null)
            {
                return NotFound();
            }
            else
            {
                modelo = await _db.Modelos.FindAsync(id);
                if (modelo == null)
                {
                    return NotFound();
                }
            }

            return View(modelo);
        }

        // POST: Cadastro/Modelos/Editar/5
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
                        _db.Add(modelo);
                        await _db.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        _db.Update(modelo);
                        await _db.SaveChangesAsync();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModeloExists(modelo.Id))
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

        // GET: Cadastro/Modelos/Excluir/5
        public async Task<IActionResult> Excluir(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modelo = await _db.Modelos
                .FirstOrDefaultAsync(m => m.Id == id);

            if (modelo == null)
            {
                return NotFound();
            }

            return View(modelo);
        }

        // POST: Cadastro/Modelos/Excluir/5
        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmarExclusao(int id)
        {
            var modelo = await _db.Modelos.FindAsync(id);

            _db.Modelos.Remove(modelo);

            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool ModeloExists(int id)
        {
            return _db.Modelos.Any(e => e.Id == id);
        }
    }
}
