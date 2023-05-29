using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio19_Subasta.Domain.Models
{
    public class PokemonLocationEntity
    {
        public int PokemonId { get; set; }
        public int LocationId { get; set; }
        public int MaxChance { get; set; }
        public int Level { get; set; }
    }
}
