using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio19_Subasta.Infrastructure.DTO
{
    public class LocationDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LocationIdentifier { get; set; }
        public string Name { get; set; }
    }
}
