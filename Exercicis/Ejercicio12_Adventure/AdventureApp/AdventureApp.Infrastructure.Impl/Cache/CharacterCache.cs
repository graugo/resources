using AdventureApp.Infrastructure.Impl.Models;
using System;
using System.Collections.Generic;

namespace AdventureApp.Infrastructure.Impl.Cache
{
    public class CharacterCache : ICharacterCache
    {
        public List<CharacterDTO> Characters => _characters;
        private List<CharacterDTO> _characters;

        public CharacterCache()
        {
            _characters = _characters ?? new List<CharacterDTO>();
        }

        public List<CharacterDTO> SetCharacters(List<CharacterDTO> characters)
        {
            if (_characters == null)
                _characters = characters;

            return _characters;
        }

        public List<CharacterDTO> AddCharacter(CharacterDTO characterDTO)
        {
            if (_characters != null)
                _characters.Add(characterDTO);

            return _characters;
        }
    }
}
