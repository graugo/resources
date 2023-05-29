using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structurals.Adapter
{
    internal class SquarePegAdapter : RoundPeg
    {
        private SquarePeg squarePeg;

        public SquarePegAdapter(SquarePeg squarePeg) : base(squarePeg.GetWidth())
        {
            this.squarePeg = squarePeg;
        }

        public int GetRadius()
        {
            return Convert.ToInt32(squarePeg.GetWidth() * Math.Sqrt(2) / 2);
        }
    }
}
