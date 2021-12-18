using Ateliex.Areas.Cadastro.Models;
using Ateliex.Data;
using Microsoft.EntityFrameworkCore;

namespace Ateliex.Areas.Cadastro.Services
{
    public class ModeloService
    {
        private readonly ApplicationDbContext _db;

        public ModeloService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<Modelo>> ObterListaModelo()
        {
            return await _db.ModeloSet.ToListAsync();
        }

        public async Task<Modelo> ObterModeloDetalhado(int? id)
        {
            return await _db.ModeloSet
                .Include(m => m.Recursos)
                .ThenInclude(r => r.Tipo)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Modelo> ObterModelo(int? id)
        {
            return await _db.ModeloSet.FindAsync(id);
        }

        public bool ModeloExists(int id)
        {
            return _db.ModeloSet.Any(e => e.Id == id);
        }

        public async Task Adicionar(Modelo entity)
        {
            _db.ModeloSet.Add(entity);

            await _db.SaveChangesAsync();
        }

        public async Task Atualizar(Modelo entity)
        {
            _db.ModeloSet.Update(entity);

            await _db.SaveChangesAsync();
        }

        public async Task Excluir(Modelo entity)
        {
            _db.ModeloSet.Remove(entity);

            await _db.SaveChangesAsync();
        }
    }
}
