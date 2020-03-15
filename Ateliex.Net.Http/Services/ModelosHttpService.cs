using Ateliex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Ateliex.Services
{
    public class ModelosHttpService : IModelosService
    {
        private readonly HttpClient client;

        public ModelosHttpService(HttpClient client)
        {
            this.client = client;
        }

        public Task<Modelo> AddAsync(Modelo modelo)
        {
            throw new NotImplementedException();
        }

        public Task<Recurso> AddRecursoAsync(Recurso recurso)
        {
            throw new NotImplementedException();
        }

        public Task RemoveRecursoAsync(string codigo, string descricao)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(string codigo)
        {
            throw new NotImplementedException();
        }

        public async Task<Modelo[]> ObtemModelosAsync()
        {
            var path = "modelos/";

            HttpResponseMessage response = await client.GetAsync(path);

            if (response.IsSuccessStatusCode)
            {
                var modelos = await response.Content.ReadAsAsync<Modelo[]>();

                return modelos;
            }

            throw new Exception();
        }

        public Task<Modelo[]> ConsultaModelosAsync(ParametrosDeConsultaDeModelos parametros)
        {
            throw new NotImplementedException();
        }
    }
}
