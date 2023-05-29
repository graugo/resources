using EX.First.Infrastructure.Impl.Models;
using EX.First.Library.Entities;
using System.Collections.Generic;
using System.Linq;

namespace EX.First.Infrastructure.Impl.Mappers
{
    public class EmpireMapper : IEmpireMapper
    {
        public IEnumerable<PriceEntity> ToPriceEntityList(IEnumerable<PriceDto> dtos)
        {
            return dtos.Select(x => new PriceEntity 
            {
                PricesPerLunarDay = x.PricesPerLunarDay,
                Sector = x.Sector
            });
        }

        public IEnumerable<RebelInfluenceEntity> ToRebelInfluenceEntityList(IEnumerable<RebelInfluenceDto> dtos)
        {
            return dtos.Select(x => new RebelInfluenceEntity
            {
                Code= x.Code,
                RebelInfluence = x.RebelInfluence
            });
        }
    }
}
