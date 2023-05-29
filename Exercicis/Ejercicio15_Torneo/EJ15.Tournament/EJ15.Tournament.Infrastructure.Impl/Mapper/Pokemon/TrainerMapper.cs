using EJ15.Tournament.Infrastructure.Impl.Models.Pokemon;
using EJ15.Tournament.Library.Models.Pokemon;
using System.Collections.Generic;
using System.Linq;

namespace EJ15.Tournament.Infrastructure.Impl.Mapper.Pokemon
{
    public class TrainerMapper : ITrainerMapper
    {
        private readonly IPokeApiMapper _pokeApiMapper;

        public TrainerMapper(IPokeApiMapper pokeApiMapper)
        {
            _pokeApiMapper = pokeApiMapper;
        }

        public IEnumerable<TrainerEntity> ToTrainerEntityList(IEnumerable<TrainerDto> dto)
        {
            return dto.Select(x => ToTrainerEntity(x));
        }

        public TrainerEntity ToTrainerEntity(TrainerDto dto) 
        {
            return new TrainerEntity
            {
                Pokemons = dto.Pokemons.Select(x => _pokeApiMapper.ToPokemonEntity(x)).ToList()
            };
        }

        public TrainerDto ToTrainerDto(TrainerEntity entity)
        {
            return new TrainerDto
            {
                Id = entity.Id,
                Pokemons = entity.Pokemons.Select(x => _pokeApiMapper.ToPokemonDto(x)).ToList()
            };
        }
    }
}
