using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveApp.Model.Strategies
{
    internal class Context
    {
        private ISaveStrategy? _strategy;
        public void SetStrategy(ISaveStrategy strategy)
        {
            _strategy = strategy;
        }

        public void ExecuteStrategy(object data)
        {
            if (_strategy != null)
            {
                _strategy.SaveData(data);
            }
        }
    }
}
