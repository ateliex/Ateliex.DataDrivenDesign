using Ateliex.Models;
using Ateliex.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Ateliex
{
    public static class InfrastructureServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<AteliexDbContext>(options =>
                options.UseSqlite(@"Data Source=Ateliex.db"));

            //services.AddTransient(typeof(IUnitOfWork), typeof(TransactionScopeManager));

            //

            //services.AddTransient<ModelosCollection>();

            services.AddTransient<ModelosInfraService>();

            //services.AddTransient<IConsultaDeModelos, ModelosInfraService>();

            //services.AddTransient<IRepositorioDeModelos, ModelosInfraService>();

            services.AddTransient<ModelosDbService>();

            services.AddTransient<ModelosHttpService>();

            //

            //services.AddTransient<PlanosComerciaisObservableCollection>();

            services.AddTransient<PlanosComerciaisInfraService>();

            //services.AddTransient<IConsultaDePlanosComerciais, PlanosComerciaisInfraService>();

            //services.AddTransient<IRepositorioDePlanosComerciais, PlanosComerciaisInfraService>();

            services.AddTransient<PlanosComerciaisDbService>();

            return services;
        }
    }
}
