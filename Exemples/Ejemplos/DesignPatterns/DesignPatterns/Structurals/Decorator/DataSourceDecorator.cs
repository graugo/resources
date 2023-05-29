using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structurals.Decorator
{
    internal class DataSourceDecorator : IDataSource
    {
        private readonly IDataSource _dataSource;

        public DataSourceDecorator(IDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public virtual string ReadData()
        {
            return _dataSource.ReadData();
        }

        public virtual void WriteData(string data)
        {
            _dataSource.WriteData(data);
        }
    }
}
