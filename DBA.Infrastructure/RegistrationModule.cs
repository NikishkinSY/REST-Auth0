using DBA.Infrastructure.ApiClients;
using DBA.Infrastructure.ApiClients.Interfaces;
using Flurl.Http.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DBA.Infrastructure
{
    public static class RegistrationModule
    {
        public static IServiceCollection RegisterInfrastructureModule(this IServiceCollection services)
        {
            return services
                .AddScoped<ICTeleportApiClient, CTeleportApiClient>()
                .AddSingleton<IFlurlClientFactory, PerBaseUrlFlurlClientFactory>();
        }
    }
}
