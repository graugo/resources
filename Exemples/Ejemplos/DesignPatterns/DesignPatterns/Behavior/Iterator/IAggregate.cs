using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behravior.Iterator
{
    internal interface IAggregate
    {
        IIterator CreateIterator();
        void Insert(int value);
    }
}
