using AdventureApp.Library.Models;
using AdventureApp.WebApi.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureApp.WebApi.Mappers
{
    public class CharacterMapper : ICharacterMapper
    {
        public CharacterResponse ToResponse(CharacterEntity characterEntity)
        {
            return new CharacterResponse
            {
                Id = characterEntity.Id,
                Name = characterEntity.Name,
                CharacterClass = characterEntity.CharacterClass,
                Strength = characterEntity.Strength,
                Dexterity = characterEntity.Dexterity,
                Intelligence = characterEntity.Intelligence,
                Weapons = ToWeaponsResponse(characterEntity.Weapons),
            };
        }
        private List<WeaponResponse> ToWeaponsResponse(List<WeaponEntity> weapons)
        {
            List<WeaponResponse> weaponResponses = new List<WeaponResponse>();
            weapons.ForEach(x => weaponResponses.Add(ToWeaponResponse(x)));
            return weaponResponses;
        }
        public WeaponResponse ToWeaponResponse(WeaponEntity weaponEntity)
        {
            return new WeaponResponse
            {
                Name = weaponEntity.Name,
                Power = weaponEntity.Power,
            };
        }
    }
}
