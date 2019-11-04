using Ateliex.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ateliex.Services
{
    public class ModelosDbService : IModelosService
    {
        private readonly AteliexDbContext db;

        public ModelosDbService(AteliexDbContext db)
        {
            this.db = db;
        }

        public Task<Modelo> CadastraModeloAsync(Modelo modelo)
        {
            throw new NotImplementedException();
        }

        public Task<Recurso> AdicionaRecursoDeModeloAsync(Recurso recurso)
        {
            throw new NotImplementedException();
        }

        public Task RemoveRecursoDeModeloAsync(string codigo, string descricao)
        {
            throw new NotImplementedException();
        }

        public Task RemoveModeloAsync(string codigo)
        {
            throw new NotImplementedException();
        }

        public async Task SaveChanges()
        {
            var items = db.ChangeTracker.Entries<Recurso>().ToArray();

            foreach (var item in items)
            {
                item.State.ToString();
            }

            await db.SaveChangesAsync();
        }

        public async Task Add(Modelo modelo)
        {
            try
            {
                await db.Modelos.AddAsync(modelo);

                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // TODO: Tratar erros de persistência aqui.

                throw new ApplicationException($"Erro ao adicionar modelo '{modelo.Codigo}'.", ex);
            }
        }

        public async Task Update(Modelo modelo)
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

        public async Task Remove(Modelo modelo)
        {
            try
            {
                db.Modelos.Remove(modelo);

                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // TODO: Tratar erros de persistência aqui.

                throw new ApplicationException($"Erro ao excluir modelo '{modelo.Codigo}'.", ex);
            }
        }

        public async Task<Modelo> ObtemModelo(string id)
        {
            try
            {
                var modelo = await db.Modelos.FindAsync(id);

                return modelo;
            }
            catch (Exception ex)
            {
                // TODO: Tratar erros de persistência aqui.

                throw new ApplicationException($"Erro ao obter modelo '{id}'.", ex);
            }
        }

        public async Task<Modelo[]> ObtemModelosAsync()
        {
            try
            {
                var planosComerciais = await db.Modelos
                    .Include(p => p.Recursos)
                    .ToArrayAsync();

                //var observable = planosComerciais.ToObservable();

                return planosComerciais;
            }
            catch (Exception ex)
            {
                // TODO: Tratar erros de persistência aqui.

                throw new ApplicationException("Erro ao obter modelos.", ex);
            }
        }

        public Task<Modelo[]> ConsultaModelosAsync(ParametrosDeConsultaDeModelos parametros)
        {
            throw new NotImplementedException();
        }
    }
}
