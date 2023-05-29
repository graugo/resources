using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryApp.Model.Button
{
    internal class MacButton : IButton
    {
        public void Paint()
        {
            Console.WriteLine("Render a button in Mac style.");
        }
    }
}
