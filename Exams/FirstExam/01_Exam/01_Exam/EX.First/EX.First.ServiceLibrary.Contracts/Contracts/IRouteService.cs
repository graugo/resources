using EX.First.Library.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EX.First.ServiceLibrary.Contracts.Contracts
{
    public interface IRouteService
    {
        Task<IEnumerable<RouteEntity>> GetRoutes();
        Task<RouteCostEntity> GetRouteCost(string origin, string destination);
    }
}
