using Exam.RouteApp.Infrastructure.Contracts.Contracts;
using Exam.RouteApp.Library.Models;
using Exam.RouteApp.ServiceLibrary.Contracts.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.RouteApp.ServiceLibrary.Impl.Implementations
{
    public class RouteService : IRouteService
    {
        private readonly IRouteRepository _routeRepository;

        public RouteService(IRouteRepository routeRepository)
        {
            _routeRepository = routeRepository;
        }
        public Task<List<PlanetEntity>> GetPlanetsAsync()
        {
            return _routeRepository.GetPlanetsAsync();
        }

        public Task<PriceEntity> GetRoutePriceAsync(string origin, string destination)
        {
            return _routeRepository.GetPriceAsync(origin, destination);
        }

        public async Task<List<RouteEntity>> GetRoutesAsync()
        {
            var planets = await _routeRepository.GetPlanetsAsync();
            List<RouteEntity> routeEntities = new List<RouteEntity>();
            foreach (var planet in planets) 
            {
                foreach (var distance in planet.Distances)
                {
                    routeEntities.Add(new RouteEntity
                    {
                        Origin = planet.Code,
                        Destination = distance.Code,
                        Distance = distance.LunarYears * 365
                    });
                }
            }
            return routeEntities;
        }
    }
}
