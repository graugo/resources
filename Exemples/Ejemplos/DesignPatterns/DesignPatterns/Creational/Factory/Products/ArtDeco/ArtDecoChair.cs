using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.Factory.Products.ArtDeco
{
    internal class ArtDecoChair : IChair
    {
        public void Sit()
        {
            Console.WriteLine($"Estas sentado en {typeof(ArtDecoChair)}");
        }
    }
}
