using HiveApp.Infrastructure.Contracts.Contracts;
using HiveApp.Library.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace HiveApp.Infrastructure.Impl.Implementations
{
    public class HiveJsonLoader : IHiveRepository
    {
        private readonly string _path;

        public HiveJsonLoader(string path) { _path = path; }
        public HiveEntity ReadHive()
        {
            HiveEntity hive = new HiveEntity();
            string jString = File.ReadAllText(_path);
            JObject jHive = JObject.Parse(jString);
            foreach (JObject jBee in jHive["colmena"]) 
            
            {
                Console.WriteLine(jBee.ToString());
                BeeEntity bee = new BeeEntity(
                    Convert.ToInt32(jBee["id"]),
                    jBee["nombre"].ToString(),
                    Convert.ToDecimal(jBee["recoleccion"]),
                    Convert.ToInt64(jBee["tiempo"]),
                    Convert.ToBoolean(jBee["estado"]),
                    Convert.ToInt32(jBee["incidentes"])
                );
                hive.AddBee( bee );
            }
            return hive;
        }
    }
}
