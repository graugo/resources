using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structurals.Decorator
{
    internal class FileDataSource : IDataSource
    {
        private string _fileName;

        public FileDataSource(string fileName)
        {
            _fileName = fileName;
        }

        public string ReadData()
        {
            return _fileName;
        }

        public void WriteData(string data)
        {
            Console.WriteLine($"Write {data} on {_fileName}");
        }
    }
}
