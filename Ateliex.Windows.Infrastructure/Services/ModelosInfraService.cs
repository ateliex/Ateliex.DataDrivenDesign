using Ateliex.Models;
using System;
using System.Threading.Tasks;

namespace Ateliex.Services
{
    public class ModelosInfraService : IModelosService
    {
        private readonly ModelosDbService db;

        public ModelosInfraService(ModelosDbService db)
        {
            this.db = db;
        }

        public async Task<Modelo> AddAsync(Modelo modelo)
        {
            await db.AddAsync(modelo);

            return modelo;
        }

        public Task<Recurso> AddRecursoAsync(Recurso recurso)
        {
            throw new NotImplementedException();
        }

        public async Task<Modelo> UpdateAsync(Modelo modelo)
        {
            await db.UpdateAsync(modelo);

            return modelo;
        }

        public async Task RemoveRecursoAsync(Recurso recurso)
        {
            await db.RemoveRecursoAsync(recurso);   
        }

        public async Task RemoveAsync(Modelo modelo)
        {
            await db.RemoveAsync(modelo);
        }

        public async Task<Modelo> ObtemModeloAsync(string id)
        {
            var result = await db.ObtemModeloAsync(id);

            return result;
        }

        public async Task<Modelo[]> ObtemModelosAsync()
        {
            var result = await db.ObtemModelosAsync();

            return result; //.Cast<Modelo[]>();
        }

        public Task<Modelo[]> ConsultaModelosAsync(ParametrosDeConsultaDeModelos parametros)
        {
            throw new NotImplementedException();
        }
    }
}
