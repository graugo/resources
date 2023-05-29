using Exam.RouteApp.Library.Models;
using Exam.RouteApp.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.RouteApp.WebApi.Mappers
{
    public class Mapper : IMapper
    {
        public List<PlanetResponse> ToPlanetResponseList(List<PlanetEntity> entities)
        {
            return entities.Select(x => ToPlanetResponse(x)).ToList();
        }
        private PlanetResponse ToPlanetResponse(PlanetEntity entity)
        {
            return new PlanetResponse
            {
                Name = entity.Name,
                Code = entity.Code,
                RebellInfluence = entity.RebellInfluence,
            };
        }
        public PriceResponse ToPriceResponse(PriceEntity entity)
        {
            return new PriceResponse
            {
                PricesPerLunarDays = entity.PricesPerLunarDays,
                Total = entity.Total,
                Taxes = ToTaxesResponse(entity.Taxes),
            };
        }

        public List<RouteResponse> ToRouteResponseList(List<RouteEntity> entities)
        {
            return entities.Select(x => ToRouteResponse(x)).ToList();
        }
        private RouteResponse ToRouteResponse(RouteEntity entity)
        {
            return new RouteResponse
            {
                Origin = entity.Origin,
                Destination = entity.Destination,
                Distance = entity.Distance,
            };
        }

        public TaxesResponse ToTaxesResponse(TaxesEntity entity)
        {
            return new TaxesResponse
            {
                OriginDefenseCost = entity.OriginDefenseCost,
                DestinationDefenseCost = entity.DestinationDefenseCost,
                EliteDefenseCost = entity.EliteDefenseCost,
            };
        }
    }
}
