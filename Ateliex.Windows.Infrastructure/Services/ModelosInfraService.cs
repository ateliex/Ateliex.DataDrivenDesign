using Ateliex.Models;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Ateliex.Services
{
    public class ModelosInfraService //: IModelosService
    {
        private readonly ModelosDbService bridge;

        private readonly AteliexDbContext db;

        public ModelosInfraService(ModelosDbService bridge, AteliexDbContext db)
        {
            this.bridge = bridge;

            this.db = db;
        }

        public async Task<Modelo> AddAsync(Modelo modelo)
        {
            await bridge.AddAsync(modelo);

            return modelo;
        }

        public Task<Recurso> AddRecursoAsync(Recurso recurso)
        {
            throw new NotImplementedException();
        }

        public async Task<Modelo> UpdateAsync(Modelo modelo)
        {
            await bridge.UpdateAsync(modelo);

            return modelo;
        }

        public async Task RemoveRecursoAsync(Recurso recurso)
        {
            await bridge.RemoveRecursoAsync(recurso);
        }

        public async Task RemoveAsync(Modelo modelo)
        {
            await bridge.RemoveAsync(modelo);
        }

        public async Task<Modelo> ObtemModeloAsync(string id)
        {
            var result = await bridge.ObtemModeloAsync(id);

            return result;
        }

        public async Task SaveChangesAsync()
        {
            await db.SaveChangesAsync();
        }

        public async Task<ObservableCollection<Modelo>> ObtemModelosAsync()
        {
            await bridge.ObtemModelosAsync();

            var collection = db.Modelos.Local.ToObservableCollection();

            return collection;

            //return result; //.Cast<ObservableCollection<Modelo>>();
        }

        public Task<ObservableCollection<Modelo>> ConsultaModelosAsync(ParametrosDeConsultaDeModelos parametros)
        {
            throw new NotImplementedException();
        }
    }
}
