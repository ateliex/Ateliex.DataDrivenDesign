using Ateliex.Data;
using Microsoft.EntityFrameworkCore;

namespace Ateliex.Modules
{
    public static class DbModule
    {
        internal static IServiceCollection AddDbServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddDatabaseDeveloperPageExceptionFilter();

            //ServiceProvider = services.BuildServiceProvider();

            //

            //var connectionString = ConfigurationManager.ConnectionStrings["Atelie"].ToString();

            //var builder = new DbContextOptionsBuilder<AtelieDbContext>();

            //container.Register(() => new AtelieDbContext(builder.UseSqlite(connectionString).Options), Lifestyle.Singleton);

            //container.Register<AteliexDbContext>(Lifestyle.Singleton);

            //

            return services;
        }

        public static async Task EnsureDatabaseCreatedAsync(IServiceScopeFactory serviceScopeFactory)
        {
            using (var serviceScope = serviceScopeFactory.CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                await db.Database.EnsureDeletedAsync();
                
                await db.Database.EnsureCreatedAsync();

                await db.Database.MigrateAsync();
            }
        }
    }
}
