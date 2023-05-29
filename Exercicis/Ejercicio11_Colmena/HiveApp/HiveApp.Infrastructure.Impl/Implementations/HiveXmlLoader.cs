using HiveApp.Infrastructure.Contracts.Contracts;
using HiveApp.Library.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace HiveApp.Infrastructure.Impl.Implementations
{
    public class HiveXmlLoader : IHiveRepository
    {
        private readonly string _path;

        public HiveXmlLoader(string path) { _path = path; }
        public HiveEntity ReadHive()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(HiveEntity));
            TextReader reader = new StringReader(File.ReadAllText(_path));
            return (HiveEntity)xmlSerializer.Deserialize(reader);
        }
    }
}
