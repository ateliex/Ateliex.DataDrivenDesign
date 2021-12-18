using Ateliex.Areas.Cadastro.Models;
using Ateliex.Data;
using Microsoft.EntityFrameworkCore;

namespace Ateliex.Areas.Cadastro.Services
{
    public static class ModeloRecursoTipoService
    {
        public static async Task<List<ModeloRecursoTipo>> GetModeloRecursoTipoAll(this AteliexDbContext db)
        {
            var list = await db.ModeloRecursoTipoSet
                //.Include(mrt => mrt.Descricao)
                .Include(m => m.Recursos)
                .ToListAsync();

            return list;
        }

        public static async Task<ModeloRecursoTipo> GetModeloRecursoTipo(this AteliexDbContext db, int id)
        {
            var item = await db.ModeloRecursoTipoSet
                //.Include(mrt => mrt.Descricao)
                .Include(mrt => mrt.Recursos)
                    .ThenInclude(mr => mr.Modelo)
                .FirstOrDefaultAsync(m => m.Id == id);

            return item;
        }
    }
}
