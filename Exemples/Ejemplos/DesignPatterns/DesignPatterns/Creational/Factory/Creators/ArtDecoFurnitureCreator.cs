using DesignPatterns.Creational.Factory.Products;
using DesignPatterns.Factory.Products.ArtDeco;

namespace DesignPatterns.Creational.Factory.Creators
{
    internal class ArtDecoFurnitureCreator : IFurnitureCreator
    {
        public IChair CreateChair()
        {
            return new ArtDecoChair();
        }

        public ICloset CreateCloset()
        {
            return new ArtDecoCloset();
        }

        public ITable CreateTable()
        {
            return new ArtDecoTable();
        }
    }
}
