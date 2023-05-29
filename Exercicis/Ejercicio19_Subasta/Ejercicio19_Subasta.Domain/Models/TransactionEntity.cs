using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio19_Subasta.Domain.Models
{
    public class TransactionEntity
    {
        public int Id { get; set; }
        public decimal OriginalValue { get; set; }
        public decimal Increment { get; set; }
        public decimal FinalValue { get; set; }
        public int AuctionId { get; set; }
    }
}
