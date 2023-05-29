using Exam.RouteApp.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exam.RouteApp.WebApi.Models
{
    public class RouteResponse
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public double Distance { get; set; }
    }
}