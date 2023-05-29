using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeightConverter.Model
{
    internal class EarthConverter : AbstractConverter
    {
        public override decimal Gravity => 9.8M;
        public override string Name => "Earth";
        public EarthConverter() {}
    }
}
