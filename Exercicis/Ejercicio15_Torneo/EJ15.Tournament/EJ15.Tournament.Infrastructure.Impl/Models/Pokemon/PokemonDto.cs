using System.Collections.Generic;

namespace EJ15.Tournament.Infrastructure.Impl.Models.Pokemon
{
    public class PokemonDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<PokemonMoveDto> Moves { get; set; }
    }
}
