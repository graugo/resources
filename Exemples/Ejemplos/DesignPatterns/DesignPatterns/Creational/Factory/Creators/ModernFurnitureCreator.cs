using DesignPatterns.Creational.Factory.Products;
using DesignPatterns.Factory.Products.Modern;

namespace DesignPatterns.Creational.Factory.Creators
{
    internal class ModernFurnitureCreator : IFurnitureCreator
    {
        public IChair CreateChair()
        {
            return new ModernChair();
        }

        public ICloset CreateCloset()
        {
            return new ModernCloset();
        }

        public ITable CreateTable()
        {
            return new ModernTable();
        }
    }
}
