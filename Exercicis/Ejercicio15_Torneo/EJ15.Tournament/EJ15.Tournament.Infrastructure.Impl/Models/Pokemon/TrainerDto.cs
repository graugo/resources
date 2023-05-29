using System;
using System.Collections.Generic;

namespace EJ15.Tournament.Infrastructure.Impl.Models.Pokemon
{
    public class TrainerDto
    {
        public Guid Id { get; set; }

        public List<PokemonDto> Pokemons { get; set; }
    }
}
