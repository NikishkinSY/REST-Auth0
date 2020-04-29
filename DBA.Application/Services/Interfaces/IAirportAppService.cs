using CTeleport.DBA.Domain.Enums;
using System.Threading.Tasks;

namespace CTeleport.DBA.Application.Services.Interfaces
{
    public interface IAirportAppService
    {
        Task<double> GetDistanceBetweenAirportsAsync(string firstAirportCode, string secondAirportCode, LenghtUnit lenghtUnit = LenghtUnit.Miles);
    }
}
