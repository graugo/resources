using System.Collections.Generic;
using WCFHttpClient.Infrastructure.Contracts.Models;
using WCFHttpClient.Library.Entity;

namespace WCFHttpClient.Infrastructure.Contracts.Mappers
{
    public class RepositoryMapper : IRepositoryMapper
    {
        public PokemonDTO ToPokemonDTO(PokemonEntity pokemonEntity)
        {
            return new PokemonDTO 
            {
                Id= pokemonEntity.Id,
                Name= pokemonEntity.Name,
                Types = ToPokemonTypesDTO(pokemonEntity.Types)
            };
        }

        public PokemonEntity ToPokemonEntity(PokemonDTO pokemonDTO)
        {
            return new PokemonEntity
            { 
                Id= pokemonDTO.Id,
                Name= pokemonDTO.Name,
                Types = ToPokemonTypes(pokemonDTO.Types)
            };
        }

        private IEnumerable<PokemonTypes> ToPokemonTypes(List<PokemonTypesDTO> types)
        {
            var list = new List<PokemonTypes>();
            foreach (var type in types)
            {
                list.Add(new PokemonTypes
                {
                    Id = type.Id,
                    Type = ToPokemonType(type.Type)
                });
            }

            return list;
        }

        private PokemonType ToPokemonType(PokemonTypeDTO type)
        {
            return new PokemonType
            {
                Name = type.Name,
                URL = type.URL
            };
        }

        private List<PokemonTypesDTO> ToPokemonTypesDTO(IEnumerable<PokemonTypes> types)
        {
            var list = new List<PokemonTypesDTO>();
            foreach (var type in types) 
            {
                list.Add(new PokemonTypesDTO 
                {
                    Id= type.Id,
                    Type = ToPokemonTypeDTO(type.Type)
                });
            }

            return list;
        }

        private PokemonTypeDTO ToPokemonTypeDTO(PokemonType pokemon) 
        {
            return new PokemonTypeDTO
            {
                Name= pokemon.Name,
                URL = pokemon.URL
            };
        }
    }
}
