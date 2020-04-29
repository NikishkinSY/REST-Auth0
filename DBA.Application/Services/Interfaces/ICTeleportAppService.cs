using CTeleport.DBA.Domain.Entities;
using System.Threading.Tasks;

namespace CTeleport.DBA.Application.Services.Interfaces
{
    public interface ICTeleportAppService
    {
        Task<Airport> GetAirportAsync(string airportCode);
    }
}
