using Ateliex.Data;
using Ateliex.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Ateliex.Services
{
    public class PlanosComerciaisDbService : IPlanosComerciaisService
    {
        private readonly AteliexDbContext db;

        public PlanosComerciaisDbService(AteliexDbContext db)
        {
            this.db = db;
        }

        //public async Task<RespostaDeConsultaDePlanosComerciais> ConsultaPlanosComerciais(ParametrosDeConsultaDePlanosComerciais parametros)
        //{
        //    var resposta = new RespostaDeConsultaDePlanosComerciais();

        //    var items = new List<ItemDeConsultaDePlanosComerciais>();

        //    items.Add(new ItemDeConsultaDePlanosComerciais { Codigo = "PC01", Nome = "Plano 01" });

        //    items.Add(new ItemDeConsultaDePlanosComerciais { Codigo = "PC02", Nome = "Plano 02" });

        //    items.Add(new ItemDeConsultaDePlanosComerciais { Codigo = "PC03", Nome = "Plano 03" });

        //    resposta.Items = items.ToArray();

        //    return await Task.FromResult(resposta);
        //}

        public async Task SaveChanges()
        {
            var items = db.ChangeTracker.Entries<ItemDePlanoComercial>().ToArray();

            foreach (var item in items)
            {
                item.State.ToString();
            }

            await db.SaveChangesAsync();
        }

        public async Task AddAsync(PlanoComercial planoComercial)
        {
            try
            {
                await db.PlanosComerciais.AddAsync(planoComercial);

                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // TODO: Tratar erros de persistência aqui.

                throw new ApplicationException($"Erro ao adicionar planoComercial '{planoComercial.Codigo}'.", ex);
            }
        }

        public async Task UpdateAsync(PlanoComercial planoComercial)
        {
            try
            {
                await db.SaveChangesAsync();
            }
            catch (Exception)
            {
                // TODO: Tratar erros de persistência aqui.

                throw new ApplicationException();
            }
        }

        public async Task RemoveAsync(PlanoComercial planoComercial)
        {
            try
            {
                db.PlanosComerciais.Remove(planoComercial);

                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // TODO: Tratar erros de persistência aqui.

                throw new ApplicationException($"Erro ao excluir planoComercial '{planoComercial.Codigo}'.", ex);
            }
        }

        public async Task<PlanoComercial> ObtemPlanoComercialAsync(string id)
        {
            try
            {
                var planoComercial = await db.PlanosComerciais.FindAsync(id);

                return planoComercial;
            }
            catch (Exception ex)
            {
                // TODO: Tratar erros de persistência aqui.

                throw new ApplicationException($"Erro ao obter planoComercial '{id}'.", ex);
            }
        }

        public async Task<PlanoComercial[]> ObtemPlanosComerciaisAsync()
        {
            try
            {
                var planosComerciais = await db.PlanosComerciais
                    .Include(p => p.Custos)
                    .Include(p => p.Itens)
                        .ThenInclude(p => p.Modelo)
                            .ThenInclude(p => p.Recursos)
                    .ToArrayAsync();

                //var observable = planosComerciais.ToObservable();

                return planosComerciais;
            }
            catch (Exception ex)
            {
                // TODO: Tratar erros de persistência aqui.

                throw new ApplicationException("Erro em Planos Comerciais.", ex);
            }
        }
    }
}
