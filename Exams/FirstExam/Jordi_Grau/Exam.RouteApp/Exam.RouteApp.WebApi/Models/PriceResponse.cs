using Exam.RouteApp.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exam.RouteApp.WebApi.Models
{
    public class PriceResponse
    {
        public double Total { get; set; }
        public double PricesPerLunarDays { get; set; }
        public TaxesResponse Taxes { get; set; }
    }
}