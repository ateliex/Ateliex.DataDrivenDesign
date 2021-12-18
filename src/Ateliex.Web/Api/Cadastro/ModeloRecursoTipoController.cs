#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ateliex.Areas.Cadastro.Models;
using Ateliex.Data;

namespace Ateliex.Api.Cadastro
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModeloRecursoTipoController : ControllerBase
    {
        private readonly AteliexDbContext _db;

        public ModeloRecursoTipoController(AteliexDbContext db)
        {
            _db = db;
        }

        // GET: api/ModeloRecursoTipo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ModeloRecursoTipo>>> GetModeloRecursoTipo()
        {
            return await _db.ModeloRecursoTipoSet.ToListAsync();
        }

        // GET: api/ModeloRecursoTipo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ModeloRecursoTipo>> GetModeloRecursoTipo(int id)
        {
            var modeloRecursoTipo = await _db.ModeloRecursoTipoSet.FindAsync(id);

            if (modeloRecursoTipo == null)
            {
                return NotFound();
            }

            return modeloRecursoTipo;
        }

        // PUT: api/ModeloRecursoTipo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModeloRecursoTipo(int id, ModeloRecursoTipo modeloRecursoTipo)
        {
            if (id != modeloRecursoTipo.Id)
            {
                return BadRequest();
            }

            _db.Entry(modeloRecursoTipo).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModeloRecursoTipoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ModeloRecursoTipo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ModeloRecursoTipo>> PostModeloRecursoTipo(ModeloRecursoTipo modeloRecursoTipo)
        {
            _db.ModeloRecursoTipoSet.Add(modeloRecursoTipo);
            await _db.SaveChangesAsync();

            return CreatedAtAction("GetModeloRecursoTipo", new { id = modeloRecursoTipo.Id }, modeloRecursoTipo);
        }

        // DELETE: api/ModeloRecursoTipo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModeloRecursoTipo(int id)
        {
            var modeloRecursoTipo = await _db.ModeloRecursoTipoSet.FindAsync(id);
            if (modeloRecursoTipo == null)
            {
                return NotFound();
            }

            _db.ModeloRecursoTipoSet.Remove(modeloRecursoTipo);
            await _db.SaveChangesAsync();

            return NoContent();
        }

        private bool ModeloRecursoTipoExists(int id)
        {
            return _db.ModeloRecursoTipoSet.Any(e => e.Id == id);
        }
    }
}
