using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WharfApp.Model.ComercialShips
{
    internal class Tennak : ComercialShip
    {
        public Tennak()
        {
            max_load = 10;
            speed = 1 / 0.7M;
            isPassenger = true;
        }
        public override void Fly()
        {
            throw new NotImplementedException();
        }
    }
}
