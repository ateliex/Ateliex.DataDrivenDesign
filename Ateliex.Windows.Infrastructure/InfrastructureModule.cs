using Ateliex.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Ateliex
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            //services.AddTransient(typeof(IUnitOfWork), typeof(TransactionScopeManager));

            //

            services.AddTransient<ModelosInfraService>();

            //services.AddTransient<IConsultaDeModelos, ModelosInfraService>();

            //services.AddTransient<IRepositorioDeModelos, ModelosInfraService>();

            //

            services.AddTransient<PlanosComerciaisInfraService>();

            //services.AddTransient<IConsultaDePlanosComerciais, PlanosComerciaisInfraService>();

            //services.AddTransient<IRepositorioDePlanosComerciais, PlanosComerciaisInfraService>();

            //

            services.AddDbServices();
            
            services.AddHttpServices();

            //

            return services;
        }
    }
}
