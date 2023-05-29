using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeightConverter.Model
{
    internal abstract class AbstractConverter
    {
        public abstract string? Name { get; }
        public abstract decimal Gravity { get; }
        public decimal ConvertWeight(decimal mass)
        {
            return mass * Gravity;
        }
        public string StringResult(decimal mass)
        {
            return String.Format("{0}: {1}N", Name, ConvertWeight(mass));
        }
    }
}
