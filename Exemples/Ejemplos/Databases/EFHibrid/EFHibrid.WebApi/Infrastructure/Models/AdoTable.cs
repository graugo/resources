using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFHibrid.WebApi.Infrastructure.Models
{
    public class AdoTable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
    }
}