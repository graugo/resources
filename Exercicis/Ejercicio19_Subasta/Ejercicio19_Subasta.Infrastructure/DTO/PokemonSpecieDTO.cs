using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio19_Subasta.Infrastructure.DTO
{
    public class PokemonSpecieDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PokemonIdentifier { get; set; }
        public string Name { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
    }
}
