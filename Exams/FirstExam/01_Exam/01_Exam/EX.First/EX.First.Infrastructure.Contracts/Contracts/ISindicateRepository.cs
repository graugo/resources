using EX.First.Library.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EX.First.Infrastructure.Contracts.Contracts
{
    public interface ISindicateRepository
    {
        Task<IEnumerable<PlanetEntity>> GetPlanets();
        Task<Dictionary<string, IEnumerable<DistanceEntity>>> GetDistances();
    }
}
