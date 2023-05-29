using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryApp.Model.Checbox
{
    internal class WinCheckbox : ICheckbox
    {
        public void Paint()
        {
            Console.WriteLine("Render a Checkbox in Windows style.");
        }
    }
}
