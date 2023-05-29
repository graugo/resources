using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Ejercicio19_Subasta.Infrastructure.DTO.API
{
    public class PokemonApiDTO
    {
        [JsonPropertyName("id")]
        public int PokemonIdentifier { get; set; }
        [JsonPropertyName("name")]
        public string? Name { get; set; }
        [JsonPropertyName("weight")]
        public decimal Weight { get; set; }
        [JsonPropertyName("height")]
        public decimal Height { get; set; }
    }
}
