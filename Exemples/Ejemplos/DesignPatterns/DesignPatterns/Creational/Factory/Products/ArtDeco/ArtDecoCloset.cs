using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.Factory.Products.ArtDeco
{
    internal class ArtDecoCloset : ICloset
    {
        public void method2()
        {
            Console.WriteLine(typeof(ArtDecoCloset));
        }
    }
}
