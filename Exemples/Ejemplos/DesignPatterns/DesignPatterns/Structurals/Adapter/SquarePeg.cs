using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structurals.Adapter
{
    internal class SquarePeg
    {
        private int width;

        public SquarePeg(int width)
        {
            this.width = width;
        }

        public int GetWidth() { return width; }
    }
}
