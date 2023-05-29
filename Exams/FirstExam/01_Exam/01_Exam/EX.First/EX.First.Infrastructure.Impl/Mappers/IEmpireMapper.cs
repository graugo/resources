using EX.First.Infrastructure.Impl.Models;
using EX.First.Library.Entities;
using System.Collections.Generic;

namespace EX.First.Infrastructure.Impl.Mappers
{
    public interface IEmpireMapper
    {
        IEnumerable<PriceEntity> ToPriceEntityList(IEnumerable<PriceDto> dtos);
        IEnumerable<RebelInfluenceEntity> ToRebelInfluenceEntityList(IEnumerable<RebelInfluenceDto> dtos);
    }
}
