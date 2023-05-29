using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WharfApp.Builder
{
    internal interface IBuilder
    {
        public void Reset();
        public void SetMaterial(string material);
        public void SetFinishes(string finishes);
        public void SetPartyRoom();
        public void SetDome();
        public void SetVarietyRoom();
    }
}
