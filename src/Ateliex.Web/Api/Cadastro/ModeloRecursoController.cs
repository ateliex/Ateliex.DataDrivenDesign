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
    public class ModeloRecursoController : ControllerBase
    {
        private readonly AteliexDbContext _db;

        public ModeloRecursoController(AteliexDbContext db)
        {
            _db = db;
        }

        // GET: api/ModeloRecurso
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ModeloRecurso>>> GetModeloRecurso()
        {
            return await _db.ModeloRecursoSet.ToListAsync();
        }

        // GET: api/ModeloRecurso/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ModeloRecurso>> GetModeloRecurso(int id)
        {
            var modeloRecurso = await _db.ModeloRecursoSet.FindAsync(id);

            if (modeloRecurso == null)
            {
                return NotFound();
            }

            return modeloRecurso;
        }

        // PUT: api/ModeloRecurso/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModeloRecurso(int id, ModeloRecurso modeloRecurso)
        {
            if (id != modeloRecurso.Id)
            {
                return BadRequest();
            }

            _db.Entry(modeloRecurso).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModeloRecursoExists(id))
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

        // POST: api/ModeloRecurso
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ModeloRecurso>> PostModeloRecurso(ModeloRecurso modeloRecurso)
        {
            _db.ModeloRecursoSet.Add(modeloRecurso);
            await _db.SaveChangesAsync();

            return CreatedAtAction("GetModeloRecurso", new { id = modeloRecurso.Id }, modeloRecurso);
        }

        // DELETE: api/ModeloRecurso/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModeloRecurso(int id)
        {
            var modeloRecurso = await _db.ModeloRecursoSet.FindAsync(id);
            if (modeloRecurso == null)
            {
                return NotFound();
            }

            _db.ModeloRecursoSet.Remove(modeloRecurso);
            await _db.SaveChangesAsync();

            return NoContent();
        }

        private bool ModeloRecursoExists(int id)
        {
            return _db.ModeloRecursoSet.Any(e => e.Id == id);
        }
    }
}
