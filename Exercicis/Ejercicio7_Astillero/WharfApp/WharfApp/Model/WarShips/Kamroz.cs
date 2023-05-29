using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WharfApp.Model.WarShips
{
    internal class Kamroz : WarShip
    {
        public Kamroz()
        {
            weapon = "ligero";
            colors = "lila cardenal y blanco hueso";
            protection = "ligeras";
        }

        public override void Fly()
        {
            throw new NotImplementedException();
        }
    }
}
