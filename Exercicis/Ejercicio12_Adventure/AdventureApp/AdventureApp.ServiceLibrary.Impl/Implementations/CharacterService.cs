using AdventureApp.Infrastructure.Contracts.Contracts;
using AdventureApp.Library.Models;
using AdventureApp.ServiceLibrary.Contracts.Contracts;
using System;

namespace AdventureApp.ServiceLibrary.Impl.Implementations
{
    public class CharacterService : ICharacterService
    {
        ICharacterRepository _characterRepository;

        public CharacterService(ICharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
        }

        public CharacterEntity CreateCharacter(string name, string characterClass, string key)
        {
            CharacterEntity character = new CharacterEntity();
            character.SetUp(name, characterClass, key);
            _characterRepository.CreateCharacter(character);
            return character;
        }

        public CharacterEntity GetCharacter(string id)
        {
            var character = _characterRepository.GetCharacter(id);
            return character;
        }
    }
}
