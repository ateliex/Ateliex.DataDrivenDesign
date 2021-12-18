using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ateliex.Areas.Cadastro.Models;
using Ateliex.Areas.Cadastro.Services;
using Ateliex.Data;

namespace Ateliex.Areas.Cadastro.Controllers
{
    [Area("Cadastro")]
    public class ModeloController : Controller
    {
        private readonly AteliexDbContext _db;

        public ModeloController(AteliexDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _db.GetModeloAll();

            return View(list);
        }

        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modelo = await _db.GetModelo(id);

            if (modelo == null)
            {
                return NotFound();
            }

            return View(modelo);
        }

        public IActionResult Create()
        {
            var modelo = new Modelo();

            return View(modelo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Codigo,Nome")] Modelo modelo)
        {
            if (ModelState.IsValid)
            {
                _db.Add(modelo);

                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(modelo);
        }

        public async Task<IActionResult> Edit(string id, string? from)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modelo = await _db.ModeloSet.FindAsync(id);

            if (modelo == null)
            {
                return NotFound();
            }

            ViewData["From"] = from;

            return View(modelo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Codigo,Nome,RowVersion")] Modelo modelo, string? from)
        {
            if (id != modelo.Codigo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(modelo);

                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModeloExists(modelo.Codigo))
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

            return View(modelo);
        }

        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modelo = await _db.GetModelo(id);

            if (modelo == null)
            {
                return NotFound();
            }

            return View(modelo);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var modelo = await _db.ModeloSet.FindAsync(id);

            _db.ModeloSet.Remove(modelo);

            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool ModeloExists(string id)
        {
            return _db.ModeloSet.Any(e => e.Codigo == id);
        }
    }
}
