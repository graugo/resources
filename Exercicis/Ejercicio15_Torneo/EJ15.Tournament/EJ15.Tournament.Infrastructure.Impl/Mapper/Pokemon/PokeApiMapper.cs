using EJ15.Tournament.Infrastructure.Impl.Models.Pokemon;
using EJ15.Tournament.Library.Models.Pokemon;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EJ15.Tournament.Infrastructure.Impl.Mapper.Pokemon
{
    public class PokeApiMapper : IPokeApiMapper
    {
        public MoveEntity ToMoveEntity(MoveDto dto)
        {
            return new MoveEntity 
            {
                Id= dto.Id,
                Name = dto.Name,
                Accuracy= dto.Accuracy ?? 0,
                Power= dto.Power ?? 0,
                Type = dto.Type?.Name
            };
        }

        public PokemonDto ToPokemonDto(PokemonEntity entity)
        {
            return new PokemonDto 
            { 
                Id = entity.Id, 
                Name = entity.Name,
                Moves = entity.Moves.Select(x => new PokemonMoveDto 
                { 
                    Move = ToPokemonMoveDto(x)
                }).ToList()
            };
        }

        private MoveDto ToPokemonMoveDto(MoveEntity x)
        {
            if(x == null) 
                return null;

            return new MoveDto 
            {
                Id= x.Id,
                Name = x.Name,
                Accuracy= x.Accuracy,
                Power= x.Power,
                Type = new MoveTypeDto 
                {
                    Name = x.Type
                }
            };
        }

        public PokemonEntity ToPokemonEntity(PokemonDto dto)
        {
            return new PokemonEntity 
            {
                Id = dto.Id,
                Name = dto.Name,
                Moves = ToPokemonMoveEntity(dto.Moves).ToList()
                
            };
        }

        private IEnumerable<MoveEntity> ToPokemonMoveEntity(List<PokemonMoveDto> moves)
        {
            return moves.Select(x => ToMoveEntity(x.Move));
        }
    }
}
