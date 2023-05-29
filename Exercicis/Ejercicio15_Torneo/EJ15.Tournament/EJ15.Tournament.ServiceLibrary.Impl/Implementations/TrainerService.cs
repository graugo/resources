using EJ15.Tournament.Infrastructure.Contracts.Contracts;
using EJ15.Tournament.Library.Models.Pokemon;
using EJ15.Tournament.ServiceLibrary.Contracts.Contract;
using EJ15.Tournament.ServiceLibrary.Impl.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace EJ15.Tournament.ServiceLibrary.Impl.Implementations
{
    public class TrainerService : ITrainerService
    {
        private readonly IPokemonRepository _pokemonRepository;
        private readonly IServiceConfiguration _serviceConfiguration;
        private readonly ITrainerRepository _trainerRepository;
        private static Random _random;

        public TrainerService(IPokemonRepository pokemonRepository, 
                              IServiceConfiguration serviceConfiguration,
                              ITrainerRepository trainerRepository)
        {
            _pokemonRepository = pokemonRepository;
            _random = new Random();
            _serviceConfiguration = serviceConfiguration;
            _trainerRepository = trainerRepository;
        }

        public async Task<Guid> CreateTrainer()
        {
            var trainer = new TrainerEntity();
            trainer.Pokemons = await GeneratePokemonList();
            await SetPokemonsMoves(trainer.Pokemons);
            if (trainer.Pokemons != null && !trainer.Pokemons.Any(x => x == null) && !trainer.Pokemons.Any(x=> x.Moves.Any(y=>y == null)))
            {
                _trainerRepository.SetTrainer(trainer);
                return trainer.Id;
            }
            return default(Guid);
        }

        private async Task SetPokemonsMoves(List<PokemonEntity> pokemons)
        {
            if (pokemons.Any(x => x == null)) 
                return;
            foreach (var pokemon in pokemons)
            {
                List<Task<MoveEntity>> taskList = new List<Task<MoveEntity>>();
                var tempMoves = pokemon.Moves;     
                for (int i = 0; i < 4; i++)
                {
                    var rnd = _random.Next(tempMoves.Count);
                    var move = tempMoves[rnd];
                    var moveTask = move.Id == 0 ?
                        _pokemonRepository.GetMoveAsync(null, move.Name) :
                        _pokemonRepository.GetMoveAsync(move.Id, null);
                    taskList.Add(moveTask);
                }
                pokemon.Moves = (await Task.WhenAll(taskList)).ToList();
            }     
        }

        private async Task<List<PokemonEntity>> GeneratePokemonList()
        {
            var list = new List<PokemonEntity>();
            var taskList = new List<Task<PokemonEntity>>();
            for (int i = 0; i < 3; i++)
            {
                var rnd = _random.Next(_serviceConfiguration.MinValueRandom, _serviceConfiguration.MaxValueRandom);
                var pokemonTask =_pokemonRepository.GetPokemonAsync(rnd);
                taskList.Add(pokemonTask);
            }
            var awaitedList = await Task.WhenAll(taskList);
            list.AddRange(awaitedList);

            return list;
        }
    }
}
