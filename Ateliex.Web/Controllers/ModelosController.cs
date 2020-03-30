using Ateliex.Models;
using Ateliex.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Ateliex.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ModelosController : ControllerBase
    {
        private readonly IModelosService modelosService;

        public ModelosController(IModelosService modelosService)
        {
            this.modelosService = modelosService;
        }

        // GET: api/Modelos
        [HttpGet]
        public async Task<Modelo[]> Get()
        {
            var modelos = await modelosService.ObtemModelosAsync();

            return modelos;
        }

        // GET: api/Modelos/5
        [HttpGet("{codigo}", Name = "Get")]
        public string Get(int codigo)
        {
            throw new NotImplementedException();
        }

        // POST: api/Modelos
        [HttpPost]
        public async Task<Modelo> Post(Modelo modelo)
        {
            var resposta = await modelosService.AddAsync(modelo);

            return resposta;
        }

        // PUT: api/Modelos/5
        [HttpPut("{codigo}")]
        public void Put(int codigo, [FromBody] string value)
        {
            throw new NotImplementedException();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{codigo}")]
        public async Task Delete(string codigo)
        {
            var modelo = await modelosService.ObtemModeloAsync(codigo);

            await modelosService.RemoveAsync(modelo);
        }
    }
}
