using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WharfApp.Model;
using WharfApp.Model.WarShips;

namespace WharfApp.Factory
{
    internal class WarFactory
    {

        public IShip CreateXenoh()
        {
            return new Xenoh();
        }

        public IShip CreateTuruk()
        {
            return new Turuk();
        }

        public IShip CreateKamroz()
        {
            return new Kamroz();
        }
    }
}
