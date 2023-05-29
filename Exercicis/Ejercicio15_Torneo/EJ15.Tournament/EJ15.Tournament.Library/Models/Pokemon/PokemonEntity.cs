using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ15.Tournament.Library.Models.Pokemon
{
    public class PokemonEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<MoveEntity> Moves { get; set; }
    }
}
