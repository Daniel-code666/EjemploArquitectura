using Microsoft.Extensions.DependencyInjection;
using WebApi.Interfaces;
using WebApi.Integrations;

namespace WebApi
{
    public static class IntegrationServicesExtension
    {
        public static IServiceCollection AddWebApiIntegrations(this IServiceCollection services)
            => services.AddScoped<IPokeApiIntegration, PokeApiIntegration>();
    }
}
