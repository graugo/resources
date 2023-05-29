using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.RouteApp.Library.Models
{
    public class PlanetEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        //public string Sector { get; set; }
        public List<PseudoDistanceEntity> Distances { get; set; }
        public int RebellInfluence { get; set; }
    }
}
