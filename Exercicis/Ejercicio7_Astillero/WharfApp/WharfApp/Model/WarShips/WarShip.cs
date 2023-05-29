using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WharfApp.Model.WarShips
{
    internal abstract class WarShip : IShip
    {
        public string? weapon { get; protected set; }
        public string? colors { get; protected set; }
        public string? protection { get; protected set; }
        public abstract void Fly();
    }
}
