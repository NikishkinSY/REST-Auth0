﻿using CTeleport.DBA.Domain;
using CTeleport.DBA.Infrastructure.ApiClients.Interfaces;
using CTeleport.DBA.Infrastructure.Entities.CTeleport;
using Flurl.Http;
using Flurl.Http.Configuration;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace CTeleport.DBA.Infrastructure.ApiClients
{
    public class CTeleportApiClient: ICTeleportApiClient
    {
        private readonly IFlurlClient _client;

        public CTeleportApiClient(
            IFlurlClientFactory flurlClientFactory,
            IOptions<AppSettings> appSettings)
        {
            _client = flurlClientFactory.Get(appSettings.Value.CTeleportBaseUrl);
        }

        public async Task<Airport> GetAirportAsync(string airportCode)
        {
            var request = CreateRequest($"airports/{airportCode}");
            return await request.GetJsonAsync<Airport>();
        }

        private IFlurlRequest CreateRequest(string path)
        {
            return _client.Request(path);
        }
    }
}
