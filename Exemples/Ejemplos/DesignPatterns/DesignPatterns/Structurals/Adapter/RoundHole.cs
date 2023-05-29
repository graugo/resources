using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structurals.Adapter
{
    internal class RoundHole
    {
        private int radius;

        public RoundHole(int radius)
        {
            this.radius = radius;
        }

        public int GetRadius() { return radius; }

        public bool Fits(RoundPeg peg)
        {
            return radius >= peg.GetRadius();
        }
    }
}
