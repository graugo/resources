using Exam.RouteApp.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exam.RouteApp.WebApi.Models
{
    public class PlanetResponse
    {
        public string Name { get; set; }
        public string Code { get; set; }
        //public string Sector { get; set; 
        public int RebellInfluence { get; set; }
    }
}