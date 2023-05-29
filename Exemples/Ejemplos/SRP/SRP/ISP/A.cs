using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.ISP
{
    internal class A : IA
    {
        public void method1()
        {
            Console.WriteLine("A");
        }

        public void method2()
        {
            throw new NotImplementedException();
        }

        public void method3()
        {
            throw new NotImplementedException();
        }
    }
}
