using Ateliex.Areas.Cadastro.Models;
using Ateliex.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ateliex.Api.Cadastro
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModeloController : ControllerBase
    {
        private readonly AteliexDbContext _db;

        public ModeloController(AteliexDbContext db)
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
        public async Task<ActionResult<Modelo>> GetModelo(string id)
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
        public async Task<IActionResult> PutModelo(string id, Modelo modelo)
        {
            if (id != modelo.Codigo)
            {
                return BadRequest();
            }

            _db.Entry(modelo).State = EntityState.Modified;

            var modeloAtual = await _db.ModeloSet
                .Include(m => m.Recursos)
                .FirstOrDefaultAsync(m => m.Codigo == id);

            if (modeloAtual == default)
            {
                return NotFound();
            }

            var recursosAdicionados = modelo.Recursos.Where(r => modeloAtual.Recursos.Any(ra => ra.Id == r.Id) == false);

            var recursosAtualizados = modelo.Recursos.Where(r => modeloAtual.Recursos.Any(ra => ra.Id == r.Id) == true);

            var recursosExcluidos = modeloAtual.Recursos.Where(ra => modelo.Recursos.Any(r => r.Id == ra.Id) == false);

            foreach (var recursoAdicionado in recursosAdicionados)
            {
                _db.Add(recursoAdicionado);
            }

            foreach (var recursoAtualizado in recursosAtualizados)
            {
                _db.Update(recursoAtualizado);
            }

            foreach (var recursoExcluido in recursosExcluidos)
            {
                _db.Remove(recursoExcluido);
            }

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
            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ModeloExists(modelo.Codigo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetModelo", new { id = modelo.Codigo }, modelo);
        }

        // DELETE: api/Modelo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModelo(string id)
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

        private bool ModeloExists(string id)
        {
            return _db.ModeloSet.Any(e => e.Codigo == id);
        }
    }
}
