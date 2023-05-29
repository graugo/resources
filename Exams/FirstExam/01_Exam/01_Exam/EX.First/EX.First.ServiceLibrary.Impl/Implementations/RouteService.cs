using EX.First.Infrastructure.C.Cache;
using EX.First.Infrastructure.Contracts;
using EX.First.Infrastructure.Contracts.Contracts;
using EX.First.Library.Entities;
using EX.First.ServiceLibrary.Contracts.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EX.First.ServiceLibrary.Impl.Implementations
{
    public class RouteService : IRouteService
    {
        private readonly ISindicateRepository _sindicateRepository;
        private readonly IEmpireRepository _empireRepository;
        private readonly IRedisCacheService _redisCache;

        public RouteService(ISindicateRepository sindicateRepository,
                            IEmpireRepository empireRepository,
                            IRedisCacheService cacheService)
        {
            _sindicateRepository = sindicateRepository;
            _empireRepository = empireRepository;
            _redisCache = cacheService;
        }

        public async Task<RouteCostEntity> GetRouteCost(string origin, string destination)
        {
            IEnumerable<RouteEntity> routes = null;
            RouteCostEntity result = null;
            if (routes == null) await GetRoutes();
            var price = (await _empireRepository.GetPrices()).FirstOrDefault();
            var rebelInfluences = await _empireRepository.GetRebelInfluence();
            if (price != null && rebelInfluences != null)
            {
                var specificRoute = routes.FirstOrDefault(x => x.Origin.ToLower() == origin.ToLower() && x.Destination.ToLower() == destination.ToLower());
                var originRebelInfluence = rebelInfluences.FirstOrDefault(x => x.Code == specificRoute.OriginCode);
                var destRebelInfluence = rebelInfluences.FirstOrDefault(x => x.Code == specificRoute.DestinationCode);

                result = new RouteCostEntity
                {
                    PricesPerLunarDay = specificRoute.Distance * price.PricesPerLunarDay,
                    Taxes = new TaxEntity
                    {
                        DestinationDefenseCost = destRebelInfluence.RebelInfluence,
                        OriginDefenseCost = originRebelInfluence.RebelInfluence
                    }
                };
            }

            return result;

        }

        public async Task<IEnumerable<RouteEntity>> GetRoutes()
        {
            List <RouteEntity> routes = null;
            if (routes == null)
            {
                routes = new List<RouteEntity>();

                var planets = await _sindicateRepository.GetPlanets();
                var distances = await _sindicateRepository.GetDistances();
                if (planets != null && distances != null)
                {
                    foreach (var distance in distances)
                    {
                        foreach (var item in distance.Value)
                        {
                            routes.Add(new RouteEntity
                            {
                                Destination = planets.FirstOrDefault(x => x.Code == item.Code).PlanetName,
                                DestinationCode = planets.FirstOrDefault(x => x.Code == item.Code).Code,
                                Origin = planets.FirstOrDefault(x => x.Code == distance.Key).PlanetName,
                                OriginCode = distance.Key,
                                Distance = item.LunarYears * 365
                            });
                        }
                    }
                    return routes;
                }
            }

            return routes;
        }
    }
}
