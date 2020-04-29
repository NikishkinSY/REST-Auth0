using CTeleport.DBA.Infrastructure.Entities.CTeleport;
using System.Threading.Tasks;

namespace CTeleport.DBA.Infrastructure.ApiClients.Interfaces
{
    public interface ICTeleportApiClient
    {
        Task<Airport> GetAirportAsync(string airportCode);
    }
}
