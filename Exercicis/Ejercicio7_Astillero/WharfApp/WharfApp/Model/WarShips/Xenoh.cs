using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WharfApp.Model.WarShips
{
    internal class Xenoh : WarShip
    {
        public Xenoh()
        {
            weapon = "pesado";
            colors = "verde nuclear y amarillo toxico";
            protection = "pesadas";
        }
        public override void Fly()
        {
            throw new NotImplementedException();
        }
    }
}
