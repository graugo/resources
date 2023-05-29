using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behravior.Iterator
{
    internal class ListIterator : IIterator
    {
        private ListAggregate _listAggregate;
        private int currentIndex;

        public ListIterator(ListAggregate listAggregate)
        {
            _listAggregate = listAggregate;
            currentIndex = -1;
        }

        public int GetCurrent()
        {
            return _listAggregate[currentIndex];
        }

        public bool MoveNext()
        {
            if (currentIndex +1 < _listAggregate.Count)
            {
                currentIndex++;
                return true;
            }
            return false;           
        }
    }
}
