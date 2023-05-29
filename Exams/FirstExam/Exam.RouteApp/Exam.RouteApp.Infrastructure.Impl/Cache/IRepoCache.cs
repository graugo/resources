using Exam.RouteApp.Infrastructure.Impl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.RouteApp.Infrastructure.Impl.Cache
{
    public interface IRepoCache
    {
        double BasePrice { get; }
        List<PlanetDTO> Planets { get; }
        List<PlanetDTO> SetPlanets(List<PlanetDTO> planets);

    }
}
