using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structurals.Composite
{
    internal interface IGraphics
    {
        void Move(int x, int y);
        void Draw();
    }
}
