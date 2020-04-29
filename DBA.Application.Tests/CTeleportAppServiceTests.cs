using AutoMapper;
using CTeleport.DBA.Infrastructure.Entities.CTeleport;
using CTeleport.DBA.Infrastructure.ApiClients.Interfaces;
using CTeleport.DBA.Application.Services;
using CTeleport.DBA.Application.Services.Interfaces;
using CTeleport.DBA.Domain.Exceptions;
using Moq;
using System;
using Xunit;
using CTeleport.DBA.Application;

namespace CTeleport.DBA.ApplicationServices.Tests
{
    public class CTeleportAppServiceTests
    {
        private ICTeleportAppService _cTeleportAppService;

        internal void Init()
        {
            var cTeleportApiClientMock = new Mock<ICTeleportApiClient>();
            cTeleportApiClientMock.Setup(a => a.GetAirportAsync(It.IsAny<string>())).ReturnsAsync(new Airport());
            cTeleportApiClientMock.Setup(a => a.GetAirportAsync("ZZZ")).ReturnsAsync(() => throw new NotFoundException(string.Empty, new Exception()));

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AppServicesProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();

            _cTeleportAppService = new CTeleportAppService(cTeleportApiClientMock.Object, mapper);
        }

        [Theory]
        [InlineData("SVO")]
        public void Airport_Get_ReturnResult(string airportCode)
        {
            // arrange
            Init();

            // act
            var result = _cTeleportAppService.GetAirportAsync(airportCode).Result;

            // assert
            Assert.NotNull(result);
        }

        [Theory]
        [InlineData("ZZZ")]
        public void Airport_Get_ThrowNotFoundException(string airportCode)
        {
            // arrange
            Init();

            // act

            // assert
            Assert.ThrowsAsync<NotFoundException>(
                async () => await _cTeleportAppService.GetAirportAsync(airportCode));
        }
    }
}
