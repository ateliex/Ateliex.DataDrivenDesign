using Microsoft.Extensions.DependencyInjection;

namespace Ateliex
{
    public static class HttpClientServiceCollectionExtensions
    {
        public static IServiceCollection AddHttpServices(this IServiceCollection services)
        {
            //services.AddDbContext<AteliexDbContext>(options =>
            //    options.UseSqlite(@"Data Source=Ateliex.db"));

            //services.AddTransient(typeof(IUnitOfWork), typeof(TransactionScopeManager));

            //services.AddTransient<ModelosInfraService>();

            //services.AddTransient<ModelosDbService>();

            //services.AddTransient<PlanosComerciaisInfraService>();

            //services.AddTransient<PlanosComerciaisDbService>();

            return services;
        }
    }
}
