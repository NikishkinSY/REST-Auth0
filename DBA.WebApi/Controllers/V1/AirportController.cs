using CTeleport.DBA.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DistanceBetweenAirports.Controllers.V1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/airport")]
    [ApiController]
    public class AirportController : ControllerBase
    {
        private readonly IAirportAppService _airportService;
        public AirportController(IAirportAppService airportService)
        {
            _airportService = airportService;
        }

        [HttpGet("get-distance-between/{firstAirportCode}/{secondAirportCode}")]
        public async Task<IActionResult> GetDistanceBetweenTwoAirports([FromRoute] string firstAirportCode, [FromRoute] string secondAirportCode)
        {
            var distance = await _airportService.GetDistanceBetweenAirportsAsync(firstAirportCode, secondAirportCode);
            return Ok(new { Value = distance });
        }
    }
}