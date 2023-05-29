using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyborgApp.Model.Builder
{
    internal class LegBuilder : IBuilder
    {
        private SuperLeg _superLeg = new SuperLeg();
        public void AddPart(string part)
        {
            this._superLeg.AddPart(part);
        }

        public void Reset()
        {
            this._superLeg = new SuperLeg();
        }

        public void SetFinishes(string finishes)
        {
            this._superLeg.SetFinihes(finishes);
        }

        public void SetMaterial(string material)
        {
            this._superLeg.SetMaterial(material);
        }

        public SuperLeg GetProduct()
        {
            return this._superLeg;
        }
    }
}
