using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategiesApp.Model
{
    internal class AddStrategy : IMathStrategy
    {
        public int Execute(int x, int y)
        {
            return x + y;
        }
    }
}
