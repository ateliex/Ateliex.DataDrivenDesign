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
using System.ComponentModel;

namespace Ateliex.Controllers
{
    public abstract class DataController<TDataEntity> : Controller
        where TDataEntity : DataEntity
    {
        private readonly ApplicationDbContext _db;

        public DataController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: TDataEntity
        public async Task<IActionResult> Index()
        {
            return View(await _db.ModeloSet.ToListAsync());
        }

        protected virtual IQueryable<TDataEntity> Query()
        {
            throw new NotImplementedException();
        }

        // GET: TDataEntity/Detalhar/5
        public async Task<IActionResult> Detalhar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modelo = await _db.ModeloSet
                .Include(m => m.Recursos)
                .ThenInclude(r => r.Tipo)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (modelo == null)
            {
                return NotFound();
            }

            return View(modelo);
        }

        // GET: TDataEntity/Criar
        public IActionResult Criar()
        {
            var modelo = new Modelo();

            return View(modelo);
        }

        // POST: TDataEntity/Criar
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

        // GET: TDataEntity/Editar/5
        public async Task<IActionResult> Editar(int? id)
        {
            Modelo modelo;

            if (id == null)
            {
                return NotFound();
            }
            else
            {
                modelo = await _db.ModeloSet.FindAsync(id);
                if (modelo == null)
                {
                    return NotFound();
                }
            }

            return View(modelo);
        }

        // POST: TDataEntity/Editar/5
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

        // GET: TDataEntity/Excluir/5
        public async Task<IActionResult> Excluir(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modelo = await _db.ModeloSet
                .FirstOrDefaultAsync(m => m.Id == id);

            if (modelo == null)
            {
                return NotFound();
            }

            return View(modelo);
        }

        // POST: TDataEntity/Excluir/5
        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmarExclusao(int id)
        {
            var modelo = await _db.ModeloSet.FindAsync(id);

            _db.ModeloSet.Remove(modelo);

            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool ModeloExists(int id)
        {
            return _db.ModeloSet.Any(e => e.Id == id);
        }
    }
}
