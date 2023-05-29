using Newtonsoft.Json;
using System;
using System.Xml.Serialization;

namespace HiveApp.Infrastructure.Contracts.Models
{
    [Serializable]
    public class BeeDTO
    {
        [XmlElement("id")]
        [JsonProperty("id")]
        public int Id { get; set; }
        [XmlElement("nombre")]
        [JsonProperty("nombre")]
        public string Name { get; set; }
        [XmlElement("recoleccion")]
        [JsonProperty("recoleccion")]
        public decimal Recollection { get; set; }
        [XmlElement("tiempo")]
        [JsonProperty("tiempo")]
        public long Time { get; set; }
        [XmlElement("estado")]
        [JsonProperty("estado")]
        public bool State { get; set; }
        [XmlElement("incidentes")]
        [JsonProperty("incidentes")]
        public int Incidents { get; set; }
    }
}
