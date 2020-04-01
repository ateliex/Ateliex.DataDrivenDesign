using Ateliex.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Ateliex
{
    public static class HttpModule
    {
        internal static IServiceCollection AddHttpServices(this IServiceCollection services)
        {
            HttpClient client = new HttpClient();

            //var baseAdresse = ConfigurationManager.AppSettings["AtelieBaseAddress"].ToString();

            //client.BaseAddress = new Uri(baseAdresse);

            client.DefaultRequestHeaders.Accept.Clear();

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            services.AddSingleton(client);

            //

            services.AddTransient<ModelosHttpService>();

            //

            return services;
        }
    }
}
