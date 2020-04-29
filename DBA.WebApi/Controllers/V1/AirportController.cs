﻿using DBA.Application.Services.Interfaces;
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

        [Authorize]
        [HttpGet("get-distance-between/{firstAirportCode}/{secondAirportCode}")]
        public async Task<IActionResult> GetDistanceBetweenTwoAirports([FromRoute] string firstAirportCode, [FromRoute] string secondAirportCode, [FromRoute] LenghtUnit measure = LenghtUnit.Miles)
        {
            var distance = await _airportService.GetDistanceBetweenAirportsAsync(firstAirportCode, secondAirportCode, measure);
            return Ok(new { Value = distance, Measure = measure.ToString()});
        }
    }
}