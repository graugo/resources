using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structurals.Composite
{
    internal class CompositeGraphic : IGraphics
    {
        private List<IGraphics> _graphics = new List<IGraphics>();

        public void Add(IGraphics graphics)
        {
            _graphics.Add(graphics);
        }

        public void Remove(IGraphics graphics)
        {
            _graphics.Remove(graphics);
        }

        public void Draw()
        {
            foreach (var item in _graphics)
            {
                item.Draw();
            }
        }

        public void Move(int x, int y)
        {
            foreach (var item in _graphics)
            {
                item.Move(x, y);
            }
        }
    }
}
