using AutoMapper;
using CTeleport.DBA.Application.Services.Interfaces;
using CTeleport.DBA.Domain.Entities;
using CTeleport.DBA.Domain.Exceptions;
using CTeleport.DBA.Infrastructure.ApiClients.Interfaces;
using System;
using System.Threading.Tasks;

namespace CTeleport.DBA.Application.Services
{
    public class CTeleportAppService: ICTeleportAppService
    {
        private readonly ICTeleportApiClient _cTeleportApiClient;
        private readonly IMapper _mapper;

        public CTeleportAppService(
            ICTeleportApiClient cTeleportApiClient,
            IMapper mapper)
        {
            _cTeleportApiClient = cTeleportApiClient;
            _mapper = mapper;
        }

        public async Task<Airport> GetAirportAsync(string airportCode)
        {
            try
            {
                var airport = await _cTeleportApiClient.GetAirportAsync(airportCode);
                return _mapper.Map<Airport>(airport);
            }
            catch (Exception ex)
            {
                throw new NotFoundException($"'{airportCode}' was not found", ex);
            }
        }
    }
}
