using EX.First.Infrastructure.Contracts.Contracts;
using EX.First.Library.Entities;
using EX.First.ServiceLibrary.Impl.Implementations;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace EX.First.ServiceLibrary.Impl.UnitTest.Route
{
    public class RouteServiceTest
    {
        Mock<ISindicateRepository> _sindicateRepositoryMock;

        public RouteServiceTest()
        {
            _sindicateRepositoryMock= new Mock<ISindicateRepository>();
        }

        [Fact]
        public async Task GetRoutes_Ok() 
        {
            _sindicateRepositoryMock.Setup(x=> x.GetPlanets()).ReturnsAsync(GetPlanetEntityList());
            _sindicateRepositoryMock.Setup(x => x.GetDistances()).ReturnsAsync(GetDistancesDictionary());
            var sut = new RouteService(_sindicateRepositoryMock.Object, null);

            var routes = await sut.GetRoutes();

            Assert.NotNull(routes);
            Assert.Equal(2, routes.Count());
        }

        [Fact]
        public async Task GetRoutes_WhenPlanetsAreNull() 
        {
            _sindicateRepositoryMock.Setup(x => x.GetPlanets()).ReturnsAsync(()=> null);
            _sindicateRepositoryMock.Setup(x => x.GetDistances()).ReturnsAsync(GetDistancesDictionary());
            
            var sut = new RouteService(_sindicateRepositoryMock.Object, null);

            var routes = await sut.GetRoutes();

            Assert.Null(routes);

        }

        [Fact]
        public async Task GetRoutes_WhenDistancesAreNull() 
        {
            _sindicateRepositoryMock.Setup(x => x.GetPlanets()).ReturnsAsync(GetPlanetEntityList());
            _sindicateRepositoryMock.Setup(x=> x.GetDistances()).ReturnsAsync(() => null);

            var sut = new RouteService(_sindicateRepositoryMock.Object, null);

            var routes = await sut.GetRoutes();

            Assert.Null(routes);
        }

        private Dictionary<string, IEnumerable<DistanceEntity>> GetDistancesDictionary()
        {
            var result = new Dictionary<string, IEnumerable<DistanceEntity>>
            {
                { "TAT", new List<DistanceEntity> { new DistanceEntity { Code = "ALD", LunarYears = 2222.7M } } },
                { "ALD", new List<DistanceEntity> { new DistanceEntity { Code = "TAT", LunarYears = 2222.7M } } }
            };

            return result;
        }

        private List<PlanetEntity> GetPlanetEntityList() 
        {
            return new List<PlanetEntity>
            {
                new PlanetEntity
                {
                    Code = "TAT",
                    PlanetName = "Tatoine",
                    Sector = "1A"
                },
                new PlanetEntity
                {
                    Code = "ALD",
                    PlanetName = "Alderan",
                    Sector = "1A"
                }
            };
        }
    }
}
