using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WharfApp.Builder
{
    internal class LuxuryDirector
    {
        public void BuildGold(IBuilder builder)
        {
            builder.SetFinishes("Diamond");
            builder.SetMaterial("Gold");
            builder.SetDome();
        }

        public void BuildPlatinum(IBuilder builder)
        {
            builder.SetFinishes("Circonium");
            builder.SetMaterial("Platinum");
            builder.SetPartyRoom();
        }
        public void BuildUranium(IBuilder builder)
        {
            builder.SetFinishes("Plutonium");
            builder.SetMaterial("Uranium");
            builder.SetVarietyRoom();
        }
    }
}
