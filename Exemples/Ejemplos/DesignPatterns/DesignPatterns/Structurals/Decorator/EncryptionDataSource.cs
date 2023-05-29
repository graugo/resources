using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structurals.Decorator
{
    internal class EncryptionDataSource : DataSourceDecorator
    {
        public EncryptionDataSource(IDataSource dataSource) : base(dataSource)
        {
        }

        public override void WriteData(string data)
        {
            base.WriteData(data);
            Console.WriteLine("Encrypted");
        }

        public override string ReadData()
        {
            Console.WriteLine("Decrypted");
            return base.ReadData();
        }
    }
}
