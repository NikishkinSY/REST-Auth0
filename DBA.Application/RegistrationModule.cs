using CTeleport.DBA.Application.Services;
using CTeleport.DBA.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CTeleport.DBA.Application
{
    public static class RegistrationModule
    {
        public static IServiceCollection RegisterApplicationModule(this IServiceCollection services)
        {
            return services
                .AddScoped<ICacheAppService, CacheAppService>()
                .AddScoped<IGeoAppService, GeoAppService>()
                .AddScoped<IAirportAppService, AirportAppService>()
                .AddScoped<ICTeleportAppService, CTeleportAppService>();
        }
    }
}
