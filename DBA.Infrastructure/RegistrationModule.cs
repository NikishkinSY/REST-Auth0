using CTeleport.DBA.Infrastructure.ApiClients;
using CTeleport.DBA.Infrastructure.ApiClients.Interfaces;
using Flurl.Http.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CTeleport.DBA.Infrastructure
{
    public static class RegistrationModule
    {
        public static IServiceCollection RegisterInfrastructureModule(this IServiceCollection services)
        {
            return services
                .AddScoped<ICTeleportApiClient, CTeleportApiClient>()
                .AddScoped<IFlurlClientFactory, PerBaseUrlFlurlClientFactory>();
        }
    }
}
