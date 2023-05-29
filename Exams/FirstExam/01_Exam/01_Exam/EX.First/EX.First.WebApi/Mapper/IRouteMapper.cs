using EX.First.Library.Entities;
using EX.First.WebApi.Models.Response;
using System.Collections.Generic;

namespace EX.First.WebApi.Mapper
{
    public interface IRouteMapper
    {
        IEnumerable<RouteResponse> ToRouteResponseList(IEnumerable<RouteEntity> entities);
        RouteCostResponse ToRouteCostResponse(RouteCostEntity entity);
    }
}
