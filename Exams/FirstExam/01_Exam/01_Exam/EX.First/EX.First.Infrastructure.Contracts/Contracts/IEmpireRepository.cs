using EX.First.Library.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EX.First.Infrastructure.Contracts.Contracts
{
    public interface IEmpireRepository
    {
        Task<IEnumerable<PriceEntity>> GetPrices();
        Task<IEnumerable<RebelInfluenceEntity>> GetRebelInfluence();
    }
}
