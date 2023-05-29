using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.RouteApp.Infrastructure.Impl.Models
{
    public class PlanetDTO
    {
        public string PlanetName { get; set; }
        public string Code { get; set; }

        public List<PseudoDistanceDTO> Distances { get; set; }
        public int Influence { get; internal set; }
    }
}
