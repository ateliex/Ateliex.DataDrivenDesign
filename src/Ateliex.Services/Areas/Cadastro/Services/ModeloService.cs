using Ateliex.Areas.Cadastro.Models;
using Ateliex.Data;
using Microsoft.EntityFrameworkCore;

namespace Ateliex.Areas.Cadastro.Services
{
    public static class ModeloService
    {
        public static async Task<List<Modelo>> GetModeloAll(this AteliexDbContext db)
        {
            var list = await db.ModeloSet
                .Include(m => m.Recursos)
                .ToListAsync();

            return list;
        }

        public static async Task<Modelo> GetModelo(this AteliexDbContext db, string codigo)
        {
            var item = await db.ModeloSet
                .Include(m => m.Recursos)
                .ThenInclude(r => r.Tipo)
                .FirstOrDefaultAsync(m => m.Codigo == codigo);

            return item;
        }
    }
}
