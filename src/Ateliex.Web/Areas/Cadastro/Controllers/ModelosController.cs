using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ateliex.Areas.Cadastro.Models;
using Ateliex.Data;
using Ateliex.Areas.Cadastro.Extensions;

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
        public async Task<IActionResult> Detalhar(string id)
        {
            string codigo = id.GetCodigo();

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
        public async Task<IActionResult> Criar([Bind("Codigo,Nome,State")] Modelo modelo)
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
        public async Task<IActionResult> Editar(string id)
        {
            string codigo = id.GetCodigo();

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

        // POST: Cadastro/Modelos/Editar/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(string id, [Bind("Codigo,Nome,State")] Modelo modelo)
        {
            string codigo = id.GetCodigo();

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

        // GET: Cadastro/Modelos/Excluir/5
        public async Task<IActionResult> Excluir(string id)
        {
            string codigo = id.GetCodigo();

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

        // POST: Cadastro/Modelos/Excluir/5
        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmarExclusao(string id)
        {
            string codigo = id.GetCodigo();

            var modelo = await _db.Modelos.FindAsync(codigo);

            _db.Modelos.Remove(modelo);
            
            await _db.SaveChangesAsync();
            
            return RedirectToAction(nameof(Index));
        }

        #region Recursos

        public async Task<IActionResult> DetalharRecurso(string id)
        {
            string codigo = id.GetCodigo();

            int? idRecurso = id.GetIdRecurso();

            if (codigo == null)
            {
                return NotFound();
            }

            var recurso = await _db.Recursos
                .Include(r => r.Modelo)
                .FirstOrDefaultAsync(r => r.ModeloCodigo == codigo && r.Id == idRecurso);

            if (recurso == null)
            {
                return NotFound();
            }

            return View(recurso);
        }

        public async Task<IActionResult> CriarRecurso(string id)
        {
            string codigo = id.GetCodigo();

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
        public async Task<IActionResult> CriarRecurso(string id, [Bind("ModeloCodigo,Id,Tipo,Descricao,Custo,Unidades")] Recurso recurso)
        {
            string codigo = id.GetCodigo();

            if (ModelState.IsValid)
            {
                _db.Add(recurso);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(recurso);
        }

        public async Task<IActionResult> EditarRecurso(string id)
        {
            string codigo = id.GetCodigo();

            int? idRecurso = id.GetIdRecurso();

            Recurso recurso;

            if (codigo == null || id == null)
            {
                return NotFound();
            }
            else
            {
                recurso = await _db.Recursos
                    .Include(r => r.Modelo)
                    .FirstOrDefaultAsync(r => r.ModeloCodigo == codigo && r.Id == idRecurso.Value);

                if (recurso == null)
                {
                    return NotFound();
                }
            }

            return View(recurso);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarRecurso(string id, [Bind("ModeloCodigo,Id,Tipo,Descricao,Custo,Unidades")] Recurso recurso)
        {
            string codigo = id.GetCodigo();

            int? idRecurso = id.GetIdRecurso();

            if (codigo != recurso.ModeloCodigo || idRecurso != recurso.Id)
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

        public async Task<IActionResult> ExcluirRecurso(string id)
        {
            string codigo = id.GetCodigo();

            int? idRecurso = id.GetIdRecurso();

            if (codigo == null || id == null)
            {
                return NotFound();
            }

            var recurso = await _db.Recursos
                .Include(r => r.Modelo)
                .FirstOrDefaultAsync(r => r.ModeloCodigo == codigo && r.Id == idRecurso);

            if (recurso == null)
            {
                return NotFound();
            }

            return View(recurso);
        }

        [HttpPost, ActionName("ExcluirRecurso")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmarExclusaoRecurso(string id)
        {
            string codigo = id.GetCodigo();

            int? idRecurso = id.GetIdRecurso();

            var recurso = await _db.Recursos.FindAsync(codigo, idRecurso);

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
