using EJ15.Tournament.Library.Models.Pokemon;
using System.Threading.Tasks;

namespace EJ15.Tournament.Infrastructure.Contracts.Contracts
{
    public interface IPokemonRepository
    {
        Task<PokemonEntity> GetPokemonAsync(int id);
        Task<MoveEntity> GetMoveAsync(int? id, string name);
    }
}
