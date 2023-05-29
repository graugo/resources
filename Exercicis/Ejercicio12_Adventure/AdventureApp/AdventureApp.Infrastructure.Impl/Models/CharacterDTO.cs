using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureApp.Infrastructure.Impl.Models
{
    public class CharacterDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CharacterClass { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Intelligence { get; set; }
        public List<WeaponDTO> Weapons { get; set; }
    }
}
