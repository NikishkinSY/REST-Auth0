using DBA.Application.Services.Interfaces;
using DBA.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet("public")]
        public IActionResult Public()
        {
            return Ok(new { Value = "public" });
        }

        [Authorize]
        [HttpGet("get-distance-between/{firstAirportCode}/{secondAirportCode}")]
        public async Task<IActionResult> GetDistanceBetweenTwoAirports([FromRoute] string firstAirportCode, [FromRoute] string secondAirportCode, [FromRoute] LenghtUnit unit = LenghtUnit.Miles)
        {
            var distance = await _airportService.GetDistanceBetweenAirportsAsync(firstAirportCode, secondAirportCode, unit);
            return Ok(new { Value = distance, Unit = unit.ToString()});
        }
    }
}