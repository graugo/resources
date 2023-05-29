using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS.Model
{
    internal class Chicken : IBird, IRunner
    {
        public void Fly()
        {
            Console.WriteLine("Barely Flies..."); ;
        }

        public void Live()
        {
            Console.WriteLine("Lives a few years"); ;
        }

        public void Run()
        {
            Console.WriteLine("Runs fast!"); ;
        }
    }
}
