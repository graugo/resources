using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.Factory.Products.ArtDeco
{
    internal class ArtDecoTable : ITable
    {
        public void method1()
        {
            Console.WriteLine(typeof(ArtDecoTable));
        }
    }
}
