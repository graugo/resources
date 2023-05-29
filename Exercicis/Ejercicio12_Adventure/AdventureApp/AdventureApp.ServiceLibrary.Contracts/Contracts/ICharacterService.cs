using AdventureApp.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureApp.ServiceLibrary.Contracts.Contracts
{
    public interface ICharacterService
    {
        CharacterEntity CreateCharacter(string name, string characterClass, string key);
        CharacterEntity GetCharacter(string id);
    }
}
