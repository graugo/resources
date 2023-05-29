using Exam.RouteApp.Infrastructure.Impl.Models;
using Exam.RouteApp.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.RouteApp.Infrastructure.Impl.Mapper
{
    public class RepoMapper : IRepoMapper
    {
        public List<PlanetEntity> ToPlanetEntitylist(List<PlanetDTO> planetDTOs)
        {
            return planetDTOs.Select(x => ToPlanetEntity(x)).ToList();
        }
        public PlanetEntity ToPlanetEntity(PlanetDTO planetDTO)
        {
            return new PlanetEntity
            {
                Name = planetDTO.PlanetName,
                Code = planetDTO.Code,
                Distances = ToPDEntityList(planetDTO.Distances),
                RebellInfluence = planetDTO.Influence
            };
        }
        private PseudoDistanceEntity ToPDEntity(PseudoDistanceDTO pdDTO)
        {
            return new PseudoDistanceEntity
            {
                Code = pdDTO.Code,
                LunarYears = pdDTO.LunarYears,
            };
        }
        private List<PseudoDistanceEntity> ToPDEntityList(List<PseudoDistanceDTO> pdDTOs)
        {
            return pdDTOs.Select(x => ToPDEntity(x)).ToList();
        }

        public PriceEntity ToPriceEntity(PriceDTO dto)
        {
            return new PriceEntity
            {
                PricesPerLunarDays = dto.PricesPerLunarDay,
                Taxes = ToTaxesEntity(dto.Taxes),
                Total = dto.TotalAmount
            };
        }
        private TaxesEntity ToTaxesEntity(TaxesDTO dto)
        {
            if (dto == null) return null;
            return new TaxesEntity
            {
                DestinationDefenseCost = dto.DestinationDefenseCost,
                EliteDefenseCost = dto.EliteDefenseCost,
                OriginDefenseCost = dto.OriginDefenseCost,
            };
        }
    }
}
