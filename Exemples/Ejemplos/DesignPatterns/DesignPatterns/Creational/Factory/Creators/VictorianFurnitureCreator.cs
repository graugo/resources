using DesignPatterns.Creational.Factory.Products;
using DesignPatterns.Factory.Products.Victorian;

namespace DesignPatterns.Creational.Factory.Creators
{
    internal class VictorianFurnitureCreator : IFurnitureCreator
    {
        public IChair CreateChair()
        {
            return new VictorianChair();
        }

        public ICloset CreateCloset()
        {
            return new VictorianCloset();
        }

        public ITable CreateTable()
        {
            return new VictorianTable();
        }
    }
}
