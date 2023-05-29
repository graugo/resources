using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio19_Subasta.Infrastructure.DTO
{
    public class HistoricDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HistoricId { get; set; }
        public bool Sold { get; set; }
        [ForeignKey("AuctionId")]
        public int AuctionId { get; set; }
        public virtual AuctionDTO Auction { get; set; }
    }
}
