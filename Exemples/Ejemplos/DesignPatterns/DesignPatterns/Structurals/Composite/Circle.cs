using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structurals.Composite
{
    internal class Circle : Dot
    {
        private int radius;

        public Circle(int x, int y, int radius) : base(x, y)
        {
            this.radius = radius;
        }

        public override void Draw()
        {
            Console.WriteLine($"Draw a circle at ({x},{y}) with radius {radius}");
        }
    }
}
