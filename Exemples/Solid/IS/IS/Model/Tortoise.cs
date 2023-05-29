using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS.Model
{
    internal class Tortoise : IReptile
    {
        public void Live()
        {
            Console.WriteLine("Lives for a long time");
        }

        public void Swim()
        {
            Console.WriteLine("Swims well"); ;
        }
    }
}
