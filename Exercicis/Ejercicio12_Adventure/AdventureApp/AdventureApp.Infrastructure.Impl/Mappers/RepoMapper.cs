using AdventureApp.Infrastructure.Impl.Models;
using AdventureApp.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureApp.Infrastructure.Impl.Mappers
{
    public class RepoMapper : IRepoMapper
    {
        public CharacterDTO ToCharacterDTO(CharacterEntity character)
        {
            return new CharacterDTO
            {
                Id = character.Id,
                Name = character.Name,
                CharacterClass = character.CharacterClass,
                Strength = character.Strength,
                Dexterity = character.Dexterity,
                Intelligence = character.Intelligence,
                Weapons = ToWeaponsDTOs(character.Weapons),
            };
        }

        private List<WeaponDTO> ToWeaponsDTOs(List<WeaponEntity> weapons)
        {
            List<WeaponDTO> list = new List<WeaponDTO>();
            weapons.ForEach(x => list.Add(ToWeaponDTO(x)));
            return list;
        }

        public CharacterEntity ToCharacterEntity(CharacterDTO character)
        {
            return new CharacterEntity
            {
                Id = character.Id,
                Name = character.Name,
                CharacterClass = character.CharacterClass,
                Strength = character.Strength,
                Dexterity = character.Dexterity,
                Intelligence = character.Intelligence,
                Weapons = ToWeaponsEntity(character.Weapons),
            };
        }

        private List<WeaponEntity> ToWeaponsEntity(List<WeaponDTO> weapons)
        {
            List<WeaponEntity> list = new List<WeaponEntity>();
            weapons.ForEach(x => list.Add(ToWeaponEntity(x)));
            return list;
        }

        public WeaponDTO ToWeaponDTO(WeaponEntity weapon)
        {
            return new WeaponDTO
            {
                Name = weapon.Name,
                Power = weapon.Power,
            };
        }

        public WeaponEntity ToWeaponEntity(WeaponDTO weaponDTO)
        {
            return new WeaponEntity
            {
                Name = weaponDTO.Name,
                Power = weaponDTO.Power,
            };
        }
    }
}
