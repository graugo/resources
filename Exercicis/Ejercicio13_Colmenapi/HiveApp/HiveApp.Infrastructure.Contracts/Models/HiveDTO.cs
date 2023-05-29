using System.Collections.Generic;
using global::HiveApp.Library.Model;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace HiveApp.Infrastructure.Contracts.Models
{
    [XmlRoot("colmena")]
    public class HiveDTO
    {
        [XmlElement("abeja")]
        [JsonProperty("colmena")]
        public List<BeeDTO> BeeList { get; set; }
    }
}


