using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio19_Subasta.Domain.Models
{
    public class PokemonSpecieEntity
    {
        public int PokemonIdentifier { get; set; }
        public string Name { get; set; }        
        public int Weight { get; set; }
        public int Height { get; set; }
    }
}
