using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Ejercicio19_Subasta.Infrastructure.DTO.API
{
    public class AreaEncounterApiDTO
    {
        [JsonPropertyName("pokemon")]
        public PokemonApiDTO Pokemon { get; set; }
        [JsonPropertyName("version_details")]
        public List<VersionDetail> VersionDetails { get; set; }

    }

    public class VersionDetail
    {
        [JsonPropertyName("max_chance")]
        public int MaxChance { get; set; }
        [JsonPropertyName("encounter_details")]
        public List<EncounterDetail> encounterDetails { get; set; }
    }

    public class EncounterDetail
    {
        [JsonPropertyName("max_level")]
        public int MaxLevel { get; set; }
        [JsonPropertyName("min_level")]

        public int MinLevel { get; set; }
    }
}
