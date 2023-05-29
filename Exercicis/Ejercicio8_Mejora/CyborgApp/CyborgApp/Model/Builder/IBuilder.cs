using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyborgApp.Model.Builder
{
    internal interface IBuilder
    {
        public void Reset();
        public void SetMaterial(string material);
        public void SetFinishes(string finishes);
        public void AddPart(string part);
    }
}
