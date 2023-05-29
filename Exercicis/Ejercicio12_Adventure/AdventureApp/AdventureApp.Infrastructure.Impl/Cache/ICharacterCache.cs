using AdventureApp.Infrastructure.Impl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureApp.Infrastructure.Impl.Cache
{
    public interface ICharacterCache
    {
        List<CharacterDTO> Characters { get; }
        List<CharacterDTO> SetCharacters(List<CharacterDTO> characters);
        List<CharacterDTO> AddCharacter(CharacterDTO character);
    }
}
