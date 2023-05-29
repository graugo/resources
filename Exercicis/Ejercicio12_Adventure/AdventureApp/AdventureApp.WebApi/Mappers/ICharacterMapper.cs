using AdventureApp.Library.Models;
using AdventureApp.WebApi.Models.Response;

namespace AdventureApp.WebApi.Mappers
{
    public interface ICharacterMapper
    {
        CharacterResponse ToResponse(CharacterEntity characterEntity);
        WeaponResponse ToWeaponResponse(WeaponEntity weaponEntity);
    }
}
