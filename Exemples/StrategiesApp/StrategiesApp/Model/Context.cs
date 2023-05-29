using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategiesApp.Model
{
    internal class Context
    {
        private IMathStrategy _strategy;

        public void SetStrategy(IMathStrategy mathStrategy)
        {
            _strategy = mathStrategy;
        }

        public int ExecuteStrategy(int x, int y)
        {
            return _strategy.Execute(x, y);
        }
    }
}
