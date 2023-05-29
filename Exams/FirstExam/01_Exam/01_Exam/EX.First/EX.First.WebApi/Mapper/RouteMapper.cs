using EX.First.Library.Entities;
using EX.First.WebApi.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EX.First.WebApi.Mapper
{
    public class RouteMapper : IRouteMapper
    {
        public RouteCostResponse ToRouteCostResponse(RouteCostEntity entity)
        {
            return new RouteCostResponse
            {
                PricesPerLunarDay = entity.PricesPerLunarDay,
                TotalAmount = entity.TotalAmount,
                Taxes = ToTaxesResponse(entity.Taxes)
            };
        }

        public IEnumerable<RouteResponse> ToRouteResponseList(IEnumerable<RouteEntity> entities)
        {
            return entities.Select(x => new RouteResponse 
            {
                Destination= x.Destination,
                Distance = x.Distance,
                Origin = x.Origin
            });
        }

        private TaxResponse ToTaxesResponse(TaxEntity taxes)
        {
            return new TaxResponse 
            {
                DestinationDefenseCost= taxes.DestinationDefenseCost,
                EliteDefenseCost= taxes.EliteDefenseCost,
                OriginDefenseCost = taxes.OriginDefenseCost
            };
        }
    }
}