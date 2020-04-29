using DBA.Domain.Entities;
using System.Threading.Tasks;

namespace DBA.Application.Services.Interfaces
{
    public interface ICTeleportAppService
    {
        Task<Airport> GetAirportAsync(string airportCode);
    }
}
