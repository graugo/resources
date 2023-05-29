using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HiveApp.WebApi.Models.Request
{
    public class BeeRequest
    {
        public string Name { get; set; }
        public decimal Recolection { get; set; }
        public long Time { get; set; }
        public bool State { get; set; }
        public int Incidents { get; set; }
    }
}