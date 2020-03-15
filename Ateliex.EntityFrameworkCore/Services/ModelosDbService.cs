using Ateliex.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
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

        public async Task<Modelo> AddAsync(Modelo modelo)
        {
            try
            {
                await db.Modelos.AddAsync(modelo);

                await db.SaveChangesAsync();

                return modelo;
            }
            catch (Exception ex)
            {
                // TODO: Tratar erros de persistência aqui.

                throw new ApplicationException($"Erro ao adicionar modelo '{modelo.Codigo}'.", ex);
            }
        }

        public Task<Recurso> AddRecursoAsync(Recurso recurso)
        {
            throw new NotImplementedException();
        }

        public async Task<Modelo> UpdateAsync(Modelo modelo)
        {
            try
            {
                await db.SaveChangesAsync();

                return modelo;
            }
            catch (Exception)
            {
                // TODO: Tratar erros de persistência aqui.

                throw new ApplicationException();
            }
        }

        public Task RemoveRecursoAsync(Recurso recurso)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveAsync(Modelo modelo)
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

        public async Task SaveChanges()
        {
            var items = db.ChangeTracker.Entries<Recurso>().ToArray();

            foreach (var item in items)
            {
                item.State.ToString();
            }

            await db.SaveChangesAsync();
        }

        public async Task<Modelo> ObtemModeloAsync(string codigo)
        {
            try
            {
                var modelo = await db.Modelos.FindAsync(codigo);

                return modelo;
            }
            catch (Exception ex)
            {
                // TODO: Tratar erros de persistência aqui.

                throw new ApplicationException($"Erro ao obter modelo '{codigo}'.", ex);
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
