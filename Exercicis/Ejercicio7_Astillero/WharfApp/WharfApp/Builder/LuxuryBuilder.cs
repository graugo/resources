using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WharfApp.Model;

namespace WharfApp.Builder
{
    internal class LuxuryBuilder : IBuilder
    {
        private LuxuryShip ship = new LuxuryShip();
        public void Reset()
        {
            ship = new LuxuryShip();
        }

        public void SetDome()
        {
            ship.HasDome = true;
        }

        public void SetFinishes(string finishes)
        {
            ship.finishes = finishes;
        }

        public void SetMaterial(string material)
        {
            ship.material = material;
        }

        public void SetPartyRoom()
        {
            ship.HaspartyRoom = true;
        }

        public void SetVarietyRoom()
        {
            ship.HasVarietyRoom = true;
        }

        public LuxuryShip Build()
        {
            return this.ship;
        }
    }
}
