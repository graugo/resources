using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdventureApp.WebApi.Models.Response
{
    public class CharacterResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CharacterClass { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Intelligence { get; set; }
        public List<WeaponResponse> Weapons { get; set;  }
    }
}