using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeightConverter.Model
{
    internal class MoonConverter : AbstractConverter
    {
        public override decimal Gravity => 1.62M;
        public override string Name => "Moon";
        public MoonConverter() 
        {}
    }
}
