using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.RouteApp.Infrastructure.Impl.Models
{
    public class PriceDTO
    {
        public double TotalAmount { get; set; }
        public double PricesPerLunarDay { get; set; }
        public TaxesDTO Taxes { get; set; }
    }
}
