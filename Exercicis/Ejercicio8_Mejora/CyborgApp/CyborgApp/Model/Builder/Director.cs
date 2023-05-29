using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyborgApp.Model.Builder
{
    internal class Director
    {
        public void ConstructBaseLeg(LegBuilder builder)
        {
            builder.Reset();
            builder.SetFinishes("Basic");
            builder.SetMaterial("Plastic");
            builder.AddPart("Joints");
        }
    }
}
