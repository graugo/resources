using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WharfApp.Model.ComercialShips
{
    internal abstract class ComercialShip : IShip
    {
        public decimal max_load { get; protected set; }
        public decimal speed { get; protected set; }
        public bool isPassenger { get; protected set; }
        public abstract void Fly();
    }
}
