using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiveApp.Library.Models
{
    public class BeeEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Recolection { get; set; }
        public long Time { get; set; }
        public bool State { get; set; }
        public int Incidents { get; set; }
    }
}
