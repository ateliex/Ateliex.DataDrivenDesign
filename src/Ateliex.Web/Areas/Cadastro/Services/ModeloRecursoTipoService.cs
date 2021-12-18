using Ateliex.Areas.Cadastro.Models;
using Ateliex.Data;
using Microsoft.EntityFrameworkCore;

namespace Ateliex.Areas.Cadastro.Services
{
    public class ModeloRecursoTipoService
    {
        private readonly ApplicationDbContext _db;

        public ModeloRecursoTipoService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<ModeloRecursoTipo>> ObterListaModeloRecursoTipo()
        {
            var modeloRecursoTipoSet = _db.ModeloRecursoTipoSet
                .Include(mrt => mrt.Descricao);

            return await modeloRecursoTipoSet.ToListAsync();
        }

        public async Task<ModeloRecursoTipo> ObterModeloRecursoTipoDetalhado(int? id)
        {
            return await _db.ModeloRecursoTipoSet
                .Include(mrt => mrt.Descricao)
                .Include(mrt => mrt.Recursos)
                .ThenInclude(mr => mr.Modelo)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<ModeloRecursoTipo> ObterModeloRecursoTipo(int? id)
        {
            return await _db.ModeloRecursoTipoSet.FindAsync(id);
        }

        public bool ModeloRecursoTipoExists(int id)
        {
            return _db.ModeloRecursoTipoSet.Any(e => e.Id == id);
        }

        public async Task Adicionar(ModeloRecursoTipo entity)
        {
            _db.ModeloRecursoTipoSet.Add(entity);

            await _db.SaveChangesAsync();
        }

        public async Task Atualizar(ModeloRecursoTipo entity)
        {
            _db.ModeloRecursoTipoSet.Update(entity);

            await _db.SaveChangesAsync();
        }

        public async Task Excluir(ModeloRecursoTipo entity)
        {
            _db.ModeloRecursoTipoSet.Remove(entity);

            await _db.SaveChangesAsync();
        }
    }
}
