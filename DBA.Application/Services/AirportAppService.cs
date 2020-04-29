using CTeleport.DBA.Application.Services.Interfaces;
using CTeleport.DBA.Domain.Entities;
using CTeleport.DBA.Domain.Enums;
using CTeleport.DBA.Domain.Exceptions;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CTeleport.DBA.Application.Services
{
    public class AirportAppService: IAirportAppService
    {
        private readonly IGeoAppService _geoService;
        private readonly ICTeleportAppService _cTeleportAppService;
        private readonly ICacheAppService _cacheService;

        public AirportAppService(
            IGeoAppService geoService,
            ICTeleportAppService cTeleportAppService,
            ICacheAppService cacheService)
        {
            _geoService = geoService;
            _cTeleportAppService = cTeleportAppService;
            _cacheService = cacheService;
        }

        public async Task<double> GetDistanceBetweenAirportsAsync(string firstAirportCode, string secondAirportCode, LenghtUnit lenghtUnit = LenghtUnit.Miles)
        {
            firstAirportCode = firstAirportCode?.ToUpper();
            secondAirportCode = secondAirportCode?.ToUpper();

            if (!IsAirportCodeValid(firstAirportCode))
            {
                throw new InvalidArgumentException($"'{firstAirportCode}' code is invalid");
            }

            if (!IsAirportCodeValid(secondAirportCode))
            {
                throw new InvalidArgumentException($"'{secondAirportCode}' code is invalid");
            }
            
            var firstAirport = await GetAirportAsync(firstAirportCode);
            var secondAirport = await GetAirportAsync(secondAirportCode);

            var distance = _geoService.Distance(
                firstAirport.Latitude, 
                firstAirport.Longitude, 
                secondAirport.Latitude, 
                secondAirport.Longitude, 
                lenghtUnit);

            return distance;
        }

        private async Task<Airport> GetAirportAsync(string airportCode)
        {
            var airport = _cacheService.Get<Airport>(airportCode);
            if (airport == null)
            {
                airport = await _cTeleportAppService.GetAirportAsync(airportCode);
                _cacheService.Set(airportCode, airport);
            }

            return airport;
        }

        private bool IsAirportCodeValid(string airportCode)
        {
            return Regex.IsMatch(airportCode, "^[A-Z]{3}$");
        }
    }
}
