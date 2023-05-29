using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio19_Subasta.Infrastructure.DTO
{
    public class TransactionDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int OriginalValue { get; set; }
        [Required]
        public int Increment { get; set; }
        [Required]
        public int FinalValue { get; set; }
        [ForeignKey("AuctionId")]
        public int AuctionId { get; set; }
        public virtual AuctionDTO Auction { get; set; }
    }
}
