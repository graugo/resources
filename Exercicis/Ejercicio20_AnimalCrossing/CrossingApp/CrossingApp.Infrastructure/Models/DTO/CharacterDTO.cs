using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossingApp.Infrastructure.Models.DTO
{
    [Table("Characters")]
    public class CharacterDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
