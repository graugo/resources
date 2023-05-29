using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.RouteApp.Library.Models
{
    public class PriceEntity
    {
        public double Total { get; set; }
        public double PricesPerLunarDays { get; set; }
        public TaxesEntity Taxes { get; set; }
    }
}
