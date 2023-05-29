using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CrossingApp.Infrastructure.Models.Deserialize
{
    public class CharacterDeserialize
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public Names? NamesList { get; set; }
    }
    public class Names
    {
        [JsonPropertyName("name-USen")]
        public string UsName { get; set; }
    }
}
