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

        public async Task Add(Modelo modelo)
        {
            await db.Add(modelo);

            await db.SaveChanges();
        }

        public async Task Update(Modelo modelo)
        {
            await db.Update(modelo);
        }

        public async Task Remove(Modelo modelo)
        {
            await db.Remove(modelo);
        }

        public async Task<Modelo> ObtemModelo(string id)
        {
            var result = await db.ObtemModelo(id);

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
    }
}
