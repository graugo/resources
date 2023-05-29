using System.Collections.Generic;

namespace WCFHttpClient.Infrastructure.Contracts.Models
{
    public class PokemonDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<PokemonTypesDTO> Types { get; set; }
    }
}
