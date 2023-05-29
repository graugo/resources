using EX.First.Infrastructure.Impl.Models;
using EX.First.Library.Entities;
using System.Collections.Generic;

namespace EX.First.Infrastructure.Impl.Mappers
{
    public interface ISindicateMapper
    {
        IEnumerable<PlanetEntity> ToPlanetEntityList(IEnumerable<PlanetDto> dtos);
        Dictionary<string, IEnumerable<DistanceEntity>> ToDistancesDictionary(Dictionary<string, IEnumerable<DistanceDto>> dtos);
    }
}
