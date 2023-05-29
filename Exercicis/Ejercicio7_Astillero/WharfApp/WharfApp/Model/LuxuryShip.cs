using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WharfApp.Model
{
    internal class LuxuryShip : IShip
    {
        public string material;
        public string finishes;
        public bool HaspartyRoom;
        public bool HasDome;
        public bool HasVarietyRoom;
        public void Fly()
        {
            throw new NotImplementedException();
        }
    }
}
