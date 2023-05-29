using Ejercicio19_Subasta.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio19_Subasta.Application.InfrastructureContracts
{
    public interface IPokemonRepository
    {
        Task<PokemonSpecieEntity> GetPokemonAsync(int id);
        Task<LocationEntity> GetLocationAreaAsync(int id);
        Task<PokemonLocationEntity> GetDetailsAsync(PokemonSpecieEntity pokemon, LocationEntity location);
    }
}
