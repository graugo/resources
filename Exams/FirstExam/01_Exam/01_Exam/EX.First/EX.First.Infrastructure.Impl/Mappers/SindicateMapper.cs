using EX.First.Infrastructure.Impl.Models;
using EX.First.Library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EX.First.Infrastructure.Impl.Mappers
{
    public class SindicateMapper : ISindicateMapper
    {
        public Dictionary<string, IEnumerable<DistanceEntity>> ToDistancesDictionary(Dictionary<string, IEnumerable<DistanceDto>> dtos)
        {
            var result = new Dictionary<string, IEnumerable<DistanceEntity>>();
            foreach (var item in dtos)
            {
                result.Add(item.Key, ToDistanceDtoList(item.Value));
            }

            return result;
        }

        public IEnumerable<PlanetEntity> ToPlanetEntityList(IEnumerable<PlanetDto> dtos)
        {
            return dtos.Select(x => new PlanetEntity 
            {
                Code= x.Code,
                PlanetName= x.PlanetName,
                Sector = x.Sector
            });
        }
        private IEnumerable<DistanceEntity> ToDistanceDtoList(IEnumerable<DistanceDto> value)
        {
            return value.Select(x => new DistanceEntity 
            {
                Code= x.Code,
                LunarYears = x.LunarYears
            });
        }
    }
}
