using Microsoft.Extensions.DependencyInjection;

namespace Ateliex
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddDbServices();

            //

            return services;
        }
    }
}
