using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.Builder
{
    internal class HouseBuilder : IHouseBuilder
    {
        private House _house = new House();

        public void BuildDoors()
        {
            _house.HasDoors = true;
        }

        public void BuildGarage()
        {
            _house.HasGarage = true;
        }

        public void BuildRoof()
        {
            _house.HasRoof = true;
        }

        public void BuildWalls()
        {
            _house.HasWalls = true;
        }

        public void BuildWindows()
        {
            _house.HasWindows = true;
        }

        public void Reset()
        {
            _house = new House();
        }

        public House Build()
        {
            return _house;
        }
    }
}
