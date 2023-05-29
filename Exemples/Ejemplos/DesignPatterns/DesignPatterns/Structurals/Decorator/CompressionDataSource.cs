using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structurals.Decorator
{
    internal class CompressionDataSource : DataSourceDecorator
    {
        public CompressionDataSource(IDataSource dataSource) : base(dataSource)
        {
        }

        public override void WriteData(string data)
        {
            base.WriteData(data);
            Console.WriteLine("Compressed");
        }

        public override string ReadData()
        {
            Console.WriteLine("Decompressed");
            return base.ReadData();
        }
    }
}
