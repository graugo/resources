using HiveApp.Infrastructure.Contracts.Contracts;
using HiveApp.Infrastructure.Contracts.Mappers;
using HiveApp.Infrastructure.Contracts.Models;
using HiveApp.Infrastructure.Impl.Config;
using HiveApp.Library.Model;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace HiveApp.Infrastructure.Impl.Implementations
{
    public class HiveRepository : IHiveRepository
    {
        private readonly IRepositoryConfiguration _configuration;
        private readonly IRepositoryMapper _mapper;

        public HiveRepository(IRepositoryConfiguration configuration, IRepositoryMapper mapper)
        {
            _configuration = configuration;
            _mapper = mapper;
        }

        public HiveEntity ReadHive()
        {
            string pathExtension = _configuration.FilePath.Split('/').Last().Split('.').Last();
            if (pathExtension.Equals("json"))
            {
                return _mapper.ToHiveEntity(readFromJson());
            }
            else if (pathExtension.Equals("xml"))
            {
                return _mapper.ToHiveEntity(readFromXML());
            }
            else return null;
        }

        private HiveDTO readFromJson()
        {
            string jString;
            string p = _configuration.FilePath;
            jString = File.ReadAllText(p);
            return JsonConvert.DeserializeObject<HiveDTO>(jString);
        }

        private HiveDTO readFromXML()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(HiveDTO));
            TextReader reader = new StringReader(File.ReadAllText(_configuration.FilePath));
            return (HiveDTO)xmlSerializer.Deserialize(reader);
        }

        public void WriteHive(HiveDTO hive)
        {
            string pathExtension = _configuration.FilePath.Split('/').Last().Split('.').Last();
            if (pathExtension.Equals("json"))
            {
                string jHive = JsonConvert.SerializeObject(hive);
                File.WriteAllText(_configuration.FilePath, jHive);
            } 
            else if (pathExtension.Equals("xml"))
            {
                // TODO Write XML
            }
        }
    }
}
