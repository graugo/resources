using DesignPatterns.Creational.Factory.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.Factory.Creators
{
    internal interface IFurnitureCreator
    {
        IChair CreateChair();
        ICloset CreateCloset();
        ITable CreateTable();
    }
}
