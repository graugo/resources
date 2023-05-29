using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio19_Subasta.Infrastructure.DTO
{
    public class PokemonLocationDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Level { get; set; }
        public int MaxChance { get; set; }

        [ForeignKey("PokemonIdentifier")]
        public int PokemonId { get; set; }
        public virtual PokemonSpecieDTO Pokemon { get; set; }

        [ForeignKey("LocationIdentifier")]
        public int LocationId { get; set; }
        public virtual LocationDTO Location { get; set; }


    }
}
