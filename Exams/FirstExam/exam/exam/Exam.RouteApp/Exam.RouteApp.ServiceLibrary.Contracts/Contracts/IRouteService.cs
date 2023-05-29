using Exam.RouteApp.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.RouteApp.ServiceLibrary.Contracts.Contracts
{
    public interface IRouteService
    {
        Task<List<PlanetEntity>> GetPlanetsAsync();
        Task<List<RouteEntity>> GetRoutesAsync();

        Task<PriceEntity> GetRoutePriceAsync(string origin, string destination);
    }
}
