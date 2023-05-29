using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS.Model
{
    internal class Dog : IMammal, IViviparo, IRunner
    {
        public void GiveBirth()
        {
            Console.WriteLine("Gives birth to more dogs!"); ;
        }

        public void Live()
        {
            Console.WriteLine("Lives well and healthy!"); ;
        }

        public void Run()
        {
            Console.WriteLine("Runs hella fast!!"); ;
        }
        public void Feed()
        {
            Console.WriteLine("Feeds milk");
        }
    }
}
