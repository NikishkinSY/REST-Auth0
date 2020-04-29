using AutoMapper;
using DBA.Infrastructure.Entities.CTeleport;
using DBA.Infrastructure.ApiClients.Interfaces;
using DBA.Application.Services;
using DBA.Application.Services.Interfaces;
using DBA.Domain.Exceptions;
using Moq;
using System;
using Xunit;
using DBA.Application;

namespace DBA.ApplicationServices.Tests
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
