using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Model
{
    internal class Multiplier : Calculator
    {
        public override double Calculate(double x, double y)
        {
            return x * y;
        }
    }
}
