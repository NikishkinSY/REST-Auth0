using CTeleport.DBA.Application.Services;
using CTeleport.DBA.Application.Services.Interfaces;
using CTeleport.DBA.Domain.Enums;
using CTeleport.DBA.Domain.Exceptions;
using Xunit;

namespace CTeleport.DBA.ApplicationServices.Tests
{
    public class GeoAppServiceTests
    {
        private IGeoAppService _geoAppService;

        internal void Init()
        {
            _geoAppService = new GeoAppService();
        }

        [Theory]
        [InlineData(0, 0, 0, 0, LenghtUnit.Miles, 0)]
        [InlineData(55.966324, 37.416574, 52.309069, 4.763385, LenghtUnit.Miles, 1332.4768223958652)]
        [InlineData(55.966324, 37.416574, 52.309069, 4.763385, LenghtUnit.Kilometers, 2144.4135792618513)]
        [InlineData(55.966324, 37.416574, 52.309069, 4.763385, LenghtUnit.NauticalMiles, 1157.1228725685692)]
        public void Coordinates_CountDistance_ReturnCorrectResult(double lat1, double lon1, double lat2, double lon2, LenghtUnit lenghtUnit, double distance)
        {
            // arrange
            Init();

            // act
            var result = _geoAppService.Distance(lat1, lon1, lat2, lon2, lenghtUnit);

            // assert
            Assert.Equal(result, distance);
        }

        [Theory]
        [InlineData(-1, -1, -1, -1)]
        public void Coordinates_CountDistance_ThrowInvalidArgumentException(double lat1, double lon1, double lat2, double lon2)
        {
            // arrange
            Init();

            // act

            // assert
            Assert.Throws<InvalidArgumentException>(
                () => _geoAppService.Distance(lat1, lon1, lat2, lon2, LenghtUnit.Miles));
        }
    }
}
