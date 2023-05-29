using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureApp.Library.Models
{
    public class CharacterEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CharacterClass { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Intelligence { get; set; }
        public List<WeaponEntity> Weapons { get; set; }

        public CharacterEntity SetUp(string name, string characterClass, string key)
        {
            Id = Guid.NewGuid();
            Name = name;
            CharacterClass = characterClass;
            Weapons = new List<WeaponEntity>();
            Weapons.Add(new WeaponEntity
            {
                Name = "Sword",
                Power = 1,
            });
            return this;
        }
    }
}
