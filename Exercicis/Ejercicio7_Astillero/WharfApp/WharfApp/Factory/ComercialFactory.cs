using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WharfApp.Model;
using WharfApp.Model.ComercialShips;

namespace WharfApp.Factory
{
    internal class ComercialFactory
    {
        public IShip CreateAlgunta()
        {
            return new Algunta();
        }

        public IShip CreateSerpent()
        {
            return new Serpent();
        }

        public IShip CreateTennak()
        {
            return new Tennak();
        }
    }
}
