using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structurals.Adapter
{
    internal class RoundPeg
    {
        private int radius;

        public RoundPeg(int radius)
        {
            this.radius = radius;
        }

        public int GetRadius() { return radius; }
    }
}
