using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.Builder
{
    internal class Director
    {
        private IHouseBuilder _houseBuilder;

        public Director(IHouseBuilder houseBuilder)
        {
            _houseBuilder = houseBuilder;
        }

        public void ChangeBuilder(IHouseBuilder houseBuilder)
        {
            _houseBuilder = houseBuilder;
        }

        public void Make(string? type = "")
        {
            _houseBuilder.Reset();
            if (type == "simple")
            {
                _houseBuilder.BuildWindows();
                _houseBuilder.BuildRoof();
                _houseBuilder.BuildWalls();
                _houseBuilder.BuildDoors();
            }
            else
            {
                _houseBuilder.BuildGarage();
            }
        }
    }
}
