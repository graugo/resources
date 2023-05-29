using AdventureApp.Infrastructure.Impl.Models;
using AdventureApp.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureApp.Infrastructure.Impl.Mappers
{
    public interface IRepoMapper
    {
        CharacterDTO ToCharacterDTO(CharacterEntity character);
        CharacterEntity ToCharacterEntity(CharacterDTO characterDTO);
        WeaponDTO ToWeaponDTO(WeaponEntity weapon);
        WeaponEntity ToWeaponEntity(WeaponDTO weaponDTO);
    }
}
