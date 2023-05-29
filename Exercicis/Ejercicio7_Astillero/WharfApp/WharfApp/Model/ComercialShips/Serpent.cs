using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WharfApp.Model.ComercialShips
{
    internal class Serpent : ComercialShip
    {
        public Serpent() 
        {
            max_load = 150;
            speed = 0.4M;
            isPassenger = true;
        }
        public override void Fly()
        {
            throw new NotImplementedException();
        }
    }
}
