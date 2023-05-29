using EJ15.Tournament.Library.Models.Pokemon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ15.Tournament.ServiceLibrary.Contracts.Contract
{
    public interface IPokemonService
    {
        Task<PokemonEntity> GetPokemonAsync(int id);
        Task<TypeEntity> GetTypeAsync(int id);
        Task<MoveEntity> GetMoveAsync(int id);
    }
}
