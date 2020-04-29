using CTeleport.DBA.Application.Services;
using CTeleport.DBA.Application.Services.Interfaces;
using CTeleport.DBA.Domain.Entities;
using CTeleport.DBA.Domain.Enums;
using CTeleport.DBA.Domain.Exceptions;
using Moq;
using Xunit;

namespace CTeleport.DBA.ApplicationServices.Tests
{
    public class AirportAppServiceTests
    {
        private IAirportAppService _airportService;

        internal void Init()
        {
            var geoServiceMock = new Mock<IGeoAppService>();
            geoServiceMock.Setup(a => 
                a.Distance(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<LenghtUnit>())).Returns(0);
            var cTeleportAppServiceMock = new Mock<ICTeleportAppService>();
            cTeleportAppServiceMock.Setup(a => a.GetAirportAsync(It.IsAny<string>())).ReturnsAsync(new Airport());
            var cacheServiceMock = new Mock<ICacheAppService>();
            cacheServiceMock.Setup(a => a.Get<Airport>(It.IsAny<string>())).Returns(new Airport());
            cacheServiceMock.Setup(a => a.Set(It.IsAny<string>(), new Airport()));

            _airportService = new AirportAppService(geoServiceMock.Object, cTeleportAppServiceMock.Object, cacheServiceMock.Object);
        }

        [Theory]
        [InlineData("AMS", "SVO", 0)]
        [InlineData("SVO", "SVO", 0)]
        [InlineData("svo", "SVO", 0)]
        public void TwoAirports_CountDistance_ReturnResult(string firstAirportCode, string secondAirportCode, double distance)
        {
            // arrange
            Init();

            // act
            var result = _airportService.GetDistanceBetweenAirportsAsync(firstAirportCode, secondAirportCode, LenghtUnit.Miles).Result;

            // assert
            Assert.Equal(result, distance);
        }

        [Theory]
        [InlineData("SVOO", "SVO")]
        [InlineData("123", "SVO")]
        public void TwoAirports_CountDistance_ThrowInvalidArgumentException(string firstAirportCode, string secondAirportCode)
        {
            // arrange
            Init();

            // act

            // assert
            Assert.ThrowsAsync<InvalidArgumentException>(
                async () => await _airportService.GetDistanceBetweenAirportsAsync(firstAirportCode, secondAirportCode, LenghtUnit.Miles));
        }
    }
}
