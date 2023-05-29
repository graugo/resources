using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EFCodeFirst.WebApi.Infrastructure.Models
{
    public class EfCodeFistModel
    {
        public int Id { get; set; }
        [Column(TypeName = "VARCHAR")]
        [MaxLength(25)]
        public string Name { get; set; }    
        public int Age { get; set; }
        public string Description { get; set; }
    }
}