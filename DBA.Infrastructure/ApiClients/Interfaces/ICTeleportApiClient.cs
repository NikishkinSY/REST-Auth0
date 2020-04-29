using DBA.Infrastructure.Entities.CTeleport;
using System.Threading.Tasks;

namespace DBA.Infrastructure.ApiClients.Interfaces
{
    public interface ICTeleportApiClient
    {
        Task<Airport> GetAirportAsync(string airportCode);
    }
}
