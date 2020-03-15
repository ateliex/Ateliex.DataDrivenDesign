using Ateliex.Windows;
using Microsoft.Extensions.DependencyInjection;

namespace Ateliex
{
    public static class WindowsServiceCollectionExtensions
    {
        public static IServiceCollection AddWindows(this IServiceCollection services)
        {
            services.AddTransient(typeof(MainWindow));

            services.AddTransient(typeof(ModelosWindow));

            //services.AddTransient(typeof(ConsultaDeModelosWindow));

            //services.AddTransient(typeof(PlanosComerciaisWindow));

            return services;
        }
    }
}
