using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.LSP
{
    internal class Subclass2 : SubClass1
    {
        public override void method1()
        {
            base.method1();
            Console.WriteLine("submethod3");
        }
    }
}
