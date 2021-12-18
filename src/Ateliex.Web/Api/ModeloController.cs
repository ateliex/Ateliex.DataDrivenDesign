using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ateliex.Areas.Cadastro.Models;
using Ateliex.Data;

namespace Ateliex.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModeloController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public ModeloController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: api/Modelo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Modelo>>> GetModelo()
        {
            return await _db.ModeloSet.ToListAsync();
        }

        // GET: api/Modelo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Modelo>> GetModelo(int id)
        {
            var modelo = await _db.ModeloSet.FindAsync(id);

            if (modelo == null)
            {
                return NotFound();
            }

            return modelo;
        }

        // PUT: api/Modelo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModelo(int id, Modelo modelo)
        {
            if (id != modelo.Id)
            {
                return BadRequest();
            }

            _db.Entry(modelo).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModeloExists(id))
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

        // POST: api/Modelo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Modelo>> PostModelo(Modelo modelo)
        {
            _db.ModeloSet.Add(modelo);
            await _db.SaveChangesAsync();

            return CreatedAtAction("GetModelo", new { id = modelo.Id }, modelo);
        }

        // DELETE: api/Modelo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModelo(int id)
        {
            var modelo = await _db.ModeloSet.FindAsync(id);
            if (modelo == null)
            {
                return NotFound();
            }

            _db.ModeloSet.Remove(modelo);
            await _db.SaveChangesAsync();

            return NoContent();
        }

        private bool ModeloExists(int id)
        {
            return _db.ModeloSet.Any(e => e.Id == id);
        }
    }
}
