using Ateliex.Data;
using Ateliex.Models;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Ateliex.Services
{
    public class PlanosComerciaisInfraService //: IPlanoComercialsService
    {
        private readonly PlanosComerciaisDbService bridge;

        private readonly AteliexDbContext db;

        public PlanosComerciaisInfraService(PlanosComerciaisDbService bridge, AteliexDbContext db)
        {
            this.bridge = bridge;

            this.db = db;
        }

        public async Task<PlanoComercial> AddAsync(PlanoComercial planoComercial)
        {
            await bridge.AddAsync(planoComercial);

            return planoComercial;
        }

        public Task<Recurso> AddRecursoAsync(Recurso recurso)
        {
            throw new NotImplementedException();
        }

        public async Task<PlanoComercial> UpdateAsync(PlanoComercial planoComercial)
        {
            await bridge.UpdateAsync(planoComercial);

            return planoComercial;
        }

        //public async Task RemoveRecursoAsync(Recurso recurso)
        //{
        //    await bridge.RemoveRecursoAsync(recurso);
        //}

        public async Task RemoveAsync(PlanoComercial planoComercial)
        {
            await bridge.RemoveAsync(planoComercial);
        }

        public async Task<PlanoComercial> ObtemPlanoComercialAsync(string id)
        {
            var result = await bridge.ObtemPlanoComercialAsync(id);

            return result;
        }

        public async Task SaveChangesAsync()
        {
            await db.SaveChangesAsync();
        }

        public async Task<ObservableCollection<PlanoComercial>> ObtemPlanosComerciaisAsync()
        {
            await bridge.ObtemPlanosComerciaisAsync();

            var collection = db.PlanosComerciais.Local.ToObservableCollection();

            return collection;

            //return result; //.Cast<ObservableCollection<PlanoComercial>>();
        }

        //public Task<ObservableCollection<PlanoComercial>> ConsultaPlanoComercialsAsync(ParametrosDeConsultaDePlanoComercials parametros)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
