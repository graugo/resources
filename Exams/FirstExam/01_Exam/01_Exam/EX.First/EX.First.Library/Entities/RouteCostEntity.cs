using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX.First.Library.Entities
{
    public class RouteCostEntity
    {
        public decimal TotalAmount => GetTotalAmount();
        public decimal PricesPerLunarDay { get; set; }
        public TaxEntity Taxes { get; set; }

        private decimal GetTotalAmount()
        {
            return PricesPerLunarDay + Taxes.GetTotal();
        }
    }
}
