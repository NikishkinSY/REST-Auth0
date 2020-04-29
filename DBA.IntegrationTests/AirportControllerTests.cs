using DistanceBetweenAirports;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace DBA.IntegrationTests
{
    // tester should do these tests using Postman or TestTrail
    public class AirportControllerTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public AirportControllerTests(WebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Trait("Category", "IntegrationTest")]
        [Theory]
        [InlineData("SVO", "AMS", "1332.4768223958652")]
        public async Task TwoAirports_GetDistance_ReturnCorrectResult(string firstAirportCode, string secondAirportCode, string distance)
        {
            var response = await _client.GetAsync($"/api/v1/airport/get-distance-between/{firstAirportCode}/{secondAirportCode}");

            var content = await response.Content.ReadAsStringAsync();

            Assert.Contains(distance, content);
        }
    }
}
