using Exam.RouteApp.Infrastructure.Impl.Models;
using Exam.RouteApp.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.RouteApp.Infrastructure.Impl.Mapper
{
    public interface IRepoMapper
    {
        List<PlanetEntity> ToPlanetEntitylist(List<PlanetDTO> planetDTOs);
        PlanetEntity ToPlanetEntity(PlanetDTO planetDTO);
        PriceEntity ToPriceEntity(PriceDTO result);
    }
}
