using Ateliex.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ateliex.Services
{
    public class ModelosLocalService : IModelosService
    {
        private readonly ModelosDbService db;

        public ModelosLocalService(ModelosDbService db)
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

        public async Task<IEnumerable<Modelo>> ObtemObservavelDeModelos()
        {
            var result = await db.ObtemObservavelDeModelos();

            return result; //.Cast<Modelo[]>();
        }

        public Modelo[] ConsultaModelos(ParametrosDeConsultaDeModelos parametros)
        {
            throw new NotImplementedException();
        }

        public Modelo CadastraModelo(Modelo modelo)
        {
            throw new NotImplementedException();
        }

        public Recurso AdicionaRecursoDeModelo(Recurso recurso)
        {
            throw new NotImplementedException();
        }

        public void RemoveRecursoDeModelo(string codigo, string descricao)
        {
            throw new NotImplementedException();
        }

        public void RemoveModelo(string codigo)
        {
            throw new NotImplementedException();
        }
    }
}
