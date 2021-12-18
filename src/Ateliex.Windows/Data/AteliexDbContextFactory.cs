using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Ateliex.Data
{
    public class AteliexDbContextFactory : IDesignTimeDbContextFactory<AteliexDbContext>
    {
        public AteliexDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AteliexDbContext>();
            optionsBuilder.UseSqlite(@"Data Source=Ateliex.db", b => b.MigrationsAssembly("Ateliex.EntityFrameworkCore.Sqlite"));

            return new AteliexDbContext(optionsBuilder.Options);
        }
    }
}
