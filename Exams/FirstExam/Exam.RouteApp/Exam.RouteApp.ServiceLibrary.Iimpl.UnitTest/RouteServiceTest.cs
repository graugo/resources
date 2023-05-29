using Exam.RouteApp.Infrastructure.Contracts.Contracts;
using Exam.RouteApp.Infrastructure.Impl.Implementations;
using Exam.RouteApp.Library.Models;
using Exam.RouteApp.ServiceLibrary.Impl.Implementations;
using Moq;
using Xunit;

namespace Exam.RouteApp.ServiceLibrary.Iimpl.UnitTest
{
    public class RouteServiceTest
    {
        private readonly Mock<IRouteRepository> _routeRepositoryMock;

        public RouteServiceTest()
        {
            _routeRepositoryMock = new Mock<IRouteRepository>();
        }

        [Fact]
        public async void Test1()
        {
            _routeRepositoryMock.Setup(x => x.GetPriceAsync(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(
                new PriceEntity
                {
                    Total = 100,
                    PricesPerLunarDays = 10,
                    Taxes = new TaxesEntity 
                    {
                        OriginDefenseCost = 100,
                        DestinationDefenseCost = 100,
                        EliteDefenseCost = 100,
                    }
                });
            var sut = new RouteService(_routeRepositoryMock.Object);
            var response = await sut.GetRoutePriceAsync("TAT", "ALD");
            Assert.NotNull(response); 
        }
    }
}