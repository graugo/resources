using AdventureApp.Library.Models;

namespace AdventureApp.Infrastructure.Contracts.Contracts
{
    public interface ICharacterRepository
    {
        CharacterEntity CreateCharacter(CharacterEntity character);
        CharacterEntity GetCharacter(string id);
    }
}
