using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio19_Subasta.Domain.Models
{
    public class HistoricEntity
    {
        public int HistoricId { get; set; }
        public bool Sold { get; set; }
        public int AuctionId { get; set; }
    }
}
