using Newtonsoft.Json;
using WCFHttpClient.Library.Entity;

namespace WCFHttpClient.Infrastructure.Contracts.Models
{
    public class PokemonTypesDTO
    {
        [JsonProperty("slot")]
        public int Id { get; set; }
        public PokemonTypeDTO Type { get; set; }
    }
}
