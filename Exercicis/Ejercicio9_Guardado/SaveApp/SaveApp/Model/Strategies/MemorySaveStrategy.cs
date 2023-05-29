using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveApp.Model.Strategies
{
    internal class MemorySaveStrategy : ISaveStrategy
    {
        public void SaveData(object data)
        {
            Console.WriteLine("Saving data to memory");
        }
    }
}
