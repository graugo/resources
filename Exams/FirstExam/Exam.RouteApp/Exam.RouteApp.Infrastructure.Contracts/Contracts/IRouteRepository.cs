using Exam.RouteApp.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.RouteApp.Infrastructure.Contracts.Contracts
{
    public interface IRouteRepository
    {
        Task<List<PlanetEntity>> GetPlanetsAsync();
        Task<PriceEntity> GetPriceAsync(string origin, string destination);
    }
}
