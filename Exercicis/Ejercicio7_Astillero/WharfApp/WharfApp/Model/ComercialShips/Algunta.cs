using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WharfApp.Model.ComercialShips
{
    internal class Algunta : ComercialShip
    {
        public Algunta()
        {
            max_load = 300M;
            speed = 0.2M;
            isPassenger = false;
        }
        public override void Fly()
        {
            throw new NotImplementedException();
        }
    }
}
