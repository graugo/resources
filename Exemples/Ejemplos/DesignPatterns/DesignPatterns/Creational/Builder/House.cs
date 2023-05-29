using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.Builder
{
    internal class House
    {
        public bool HasWindows { get; set; }
        public bool HasDoors { get; set; }
        public bool HasRoof { get; set; }
        public bool HasWalls { get; set; }
        public bool HasGarage { get; set; }
    }
}
