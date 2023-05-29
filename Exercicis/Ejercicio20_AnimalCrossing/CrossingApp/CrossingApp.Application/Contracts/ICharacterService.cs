using CrossingApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossingApp.Application.Contracts
{
    public interface ICharacterService
    {
        Task<CharacterEntity> GetCharacter(int id);
    }
}
