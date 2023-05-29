using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeightConverter.Model
{
    internal class SaturnConverter : AbstractConverter
    {
        public override decimal Gravity => 10.44M;
        public override string Name => "Saturn";
        public SaturnConverter()
        {}
    }
}
