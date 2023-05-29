using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exam.RouteApp.WebApi.Models
{
    public class TaxesResponse
    {
        public double OriginDefenseCost { get; set; }
        public double DestinationDefenseCost { get; set; }
        public double EliteDefenseCost { get; set; }
    }
}