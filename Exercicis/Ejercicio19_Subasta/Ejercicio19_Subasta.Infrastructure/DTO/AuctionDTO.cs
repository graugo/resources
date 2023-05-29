using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio19_Subasta.Infrastructure.DTO
{
    public class AuctionDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AuctionId { get; set; }
        public string AuctionName { get; set; }
        public decimal EntryPrice { get; set; }
        public decimal ActualPrice { get; set; }
        public int NumberBid { get; set; }
        public TimeSpan Created { get; set; }

        [ForeignKey("PokemonLocationId")]
        public int PokemonLocationId { get; set; }
        public virtual PokemonLocationDTO PokemonLocation { get; set; }

        public bool IsShiny { get; set; }
    }
}
