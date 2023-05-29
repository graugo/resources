using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio19_Subasta.Domain.Models
{
    public class LocationEntity
    {
        public int LocationIdentifier => GetId();
        public string Name { get; set; }
        public string URL { get; set; }
        private int GetId()
        {
            var locationUrlArray = URL.Split('/');
            return int.Parse(locationUrlArray[locationUrlArray.Length - 2]);
        }
    }
}
