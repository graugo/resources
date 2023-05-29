using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ15.Tournament.Library.Models.Pokemon
{
    public class TrainerEntity
    {
        public Guid Id { get; private set; }

        public List<PokemonEntity> Pokemons { get; set; }

        public TrainerEntity()
        {
            Id = Guid.NewGuid();
        }
    }
}
