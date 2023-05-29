using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behravior.Iterator
{
    internal class ListAggregate : IAggregate
    {
        private List<int> collection;

        public ListAggregate()
        {
            collection = new List<int>();
        }

        public IIterator CreateIterator()
        {
            return new ListIterator(this);
        }

        public void Insert(int value)
        {
            collection.Add(value);
        }

        public int Count { get { return collection.Count; } }

        public int this[int index] 
        { get { return collection[index]; } 
          set { collection.Insert(index, value); }
        }
    }
}
