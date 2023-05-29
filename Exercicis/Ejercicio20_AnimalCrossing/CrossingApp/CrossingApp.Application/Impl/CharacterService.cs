using CrossingApp.Application.Contracts;
using CrossingApp.Application.ContractsInfra;
using CrossingApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossingApp.Application.Impl
{
    public class CharacterService : ICharacterService
    {
        private readonly ICharacterRepo _repo;

        public CharacterService(ICharacterRepo repo)
        {
            _repo = repo;
        }

        public async Task<CharacterEntity> GetCharacter(int id)
        {
            return await _repo.GetCharacter(id);
        }
    }
}
