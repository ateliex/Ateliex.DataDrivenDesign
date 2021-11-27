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

        // GET: Cadastro/Modelos/Item/5
        public async Task<IActionResult> Item(string codigo)
        {
            if (codigo == null)
            {
                return NotFound();
            }

            var modelo = await _db.Modelos
                .Include(m => m.Recursos)
                .FirstOrDefaultAsync(m => m.Codigo == codigo);

            if (modelo == null)
            {
                return NotFound();
            }

            return View(modelo);
        }

        // GET: Cadastro/Modelos/Novo
        [Route("[area]/[controller]/Novo")]
        public IActionResult Novo()
        {
            var modelo = new Modelo();

            return View(modelo);
        }

        // POST: Cadastro/Modelos/Novo
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("[area]/[controller]/Novo")]
        public async Task<IActionResult> Novo([Bind("Codigo,Nome,State")] Modelo modelo)
        {
            if (ModelState.IsValid)
            {
                _db.Add(modelo);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(modelo);
        }

        // GET: Cadastro/Modelos/Edicao/5
        public async Task<IActionResult> Edicao(string codigo)
        {
            Modelo modelo;
            if (codigo == null)
            {
                return NotFound();
            }
            else
            {
                modelo = await _db.Modelos.FindAsync(codigo);
                if (modelo == null)
                {
                    return NotFound();
                }
            }

            return View(modelo);
        }

        // POST: Cadastro/Modelos/Edicao/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edicao(string codigo, [Bind("Codigo,Nome,State")] Modelo modelo)
        {
            if (codigo != modelo.Codigo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (codigo == null)
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
                    if (!ModeloExists(modelo.Codigo))
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

        // GET: Cadastro/Modelos/Exclusao/5
        public async Task<IActionResult> Exclusao(string codigo)
        {
            if (codigo == null)
            {
                return NotFound();
            }

            var modelo = await _db.Modelos
                .FirstOrDefaultAsync(m => m.Codigo == codigo);
            if (modelo == null)
            {
                return NotFound();
            }

            return View(modelo);
        }

        // POST: Cadastro/Modelos/Exclusao/5
        [HttpPost, ActionName("Exclusao")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ExclusaoConfirmada(string codigo)
        {
            var modelo = await _db.Modelos.FindAsync(codigo);
            _db.Modelos.Remove(modelo);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        #region Recursos

        [Route("[area]/[controller]/{codigo}/Recursos/{id}")]
        public async Task<IActionResult> RecursosItem(string codigo, int id)
        {
            if (codigo == null)
            {
                return NotFound();
            }

            var recurso = await _db.Recursos
                .Include(r => r.Modelo)
                .FirstOrDefaultAsync(r => r.ModeloCodigo == codigo && r.Id == id);

            if (recurso == null)
            {
                return NotFound();
            }

            return View(recurso);
        }

        [Route("[area]/[controller]/{codigo}/Recursos/RecursosNovo")]
        public async Task<IActionResult> RecursosNovo(string codigo)
        {
            var modelo = await _db.Modelos
                .Include(m => m.Recursos)
                .FirstOrDefaultAsync(m => m.Codigo == codigo);

            var recurso = new Recurso();

            recurso.Modelo = modelo;
            recurso.ModeloCodigo = codigo;

            return View(recurso);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("[area]/[controller]/{codigo}/Recursos/RecursosNovo")]
        public async Task<IActionResult> RecursosNovo([Bind("ModeloCodigo,Id,Tipo,Descricao,Custo,Unidades")] Recurso recurso)
        {
            if (ModelState.IsValid)
            {
                _db.Add(recurso);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(recurso);
        }

        [Route("[area]/[controller]/{codigo}/Recursos/{id}/RecursosEdicao")]
        public async Task<IActionResult> RecursosEdicao(string codigo, int? id)
        {
            Recurso recurso;

            if (codigo == null || id == null)
            {
                return NotFound();
            }
            else
            {
                recurso = await _db.Recursos
                    .Include(r => r.Modelo)
                    .FirstOrDefaultAsync(r => r.ModeloCodigo == codigo && r.Id == id.Value);

                if (recurso == null)
                {
                    return NotFound();
                }
            }

            return View(recurso);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("[area]/[controller]/{codigo}/Recursos/{id}/RecursosEdicao")]
        public async Task<IActionResult> RecursosEdicao(string codigo, int? id, [Bind("ModeloCodigo,Id,Tipo,Descricao,Custo,Unidades")] Recurso recurso)
        {
            if (codigo != recurso.ModeloCodigo || id != recurso.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (codigo == null)
                    {
                        _db.Add(recurso);
                        await _db.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        _db.Update(recurso);
                        await _db.SaveChangesAsync();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModeloExists(recurso.ModeloCodigo))
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
            return View(recurso);
        }

        [Route("[area]/[controller]/{codigo}/Recursos/{id}/RecursosExclusao")]
        public async Task<IActionResult> RecursosExclusao(string codigo, int? id)
        {
            if (codigo == null || id == null)
            {
                return NotFound();
            }

            var recurso = await _db.Recursos
                .Include(r => r.Modelo)
                .FirstOrDefaultAsync(r => r.ModeloCodigo == codigo && r.Id == id);

            if (recurso == null)
            {
                return NotFound();
            }

            return View(recurso);
        }

        [HttpPost, ActionName("RecursosExclusao")]
        [ValidateAntiForgeryToken]
        [Route("[area]/[controller]/{codigo}/Recursos/{id}/RecursosExclusao")]
        public async Task<IActionResult> RecursosExclusaoConfirmada(string codigo, int? id)
        {
            var recurso = await _db.Recursos.FindAsync(codigo, id);
            _db.Recursos.Remove(recurso);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        #endregion

        private bool ModeloExists(string codigo)
        {
            return _db.Modelos.Any(e => e.Codigo == codigo);
        }
    }
}
