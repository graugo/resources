using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Model
{
    internal class Divider : Calculator
    {
        public override double Calculate(double x, double y)
        {
            if (y == 0) 
            {
                Console.WriteLine("Cannot divide by zero");
                return 0;
            }
            return x / y;
        }
    }
}
