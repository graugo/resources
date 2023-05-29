using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WharfApp.Model.WarShips
{
    internal class Turuk : WarShip
    {
        public Turuk()
        {
            weapon = "estandard";
            colors = "azul electrico y naranja metalico";
            protection = "estandard";
        }
        public override void Fly()
        {
            throw new NotImplementedException();
        }
    }
}
