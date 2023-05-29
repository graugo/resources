using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveApp.Model.Strategies
{
    internal class FileSaveStrategy : ISaveStrategy
    {
        public void SaveData(object data)
        {
            Console.WriteLine("saving data to file");
        }
    }
}
