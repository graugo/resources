using AutoMapper;
using Ejercicio19_Subasta.Application.InfrastructureContracts;
using Ejercicio19_Subasta.CrossCutting.Redis;
using Ejercicio19_Subasta.Domain.Models;
using Ejercicio19_Subasta.Infrastructure.Callers;
using Ejercicio19_Subasta.Infrastructure.DTO;
using Ejercicio19_Subasta.Infrastructure.DTO.API;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Ejercicio19_Subasta.Infrastructure.Implementation
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly IMapper _mapper;
        private readonly ITypedHttpClient _client;
        private readonly IConfiguration _config;
        private readonly string _pokeApiUrl;
        private readonly IRedisCache _redisCache;
        private readonly ILogger<PokemonRepository> _logger;

        public PokemonRepository(IMapper mapper, ITypedHttpClient client, IRedisCache redisCache, ILogger<PokemonRepository> logger)
        {
            _logger = logger;
            _redisCache = redisCache;
            _mapper = mapper;
            _client = client;
        }

        public async Task<PokemonLocationEntity> GetDetailsAsync(PokemonSpecieEntity pokemon, LocationEntity location)
        {
            _logger.LogInformation("Getting pokemon details");
            try
            {

            var res = await _redisCache.GetAsync<PokemonLocationEntity>($"Details:{pokemon.PokemonIdentifier}:{location.LocationIdentifier}");

            if (res == null)
            {
                var urlAux = $"location-area/{location.LocationIdentifier}";
                var response = await _client.GetAsync<AreaApiDTO>(urlAux);

                if (response == null) return null;

                var encounter = response.AreaEncounters.Where(x => x.Pokemon.Name == pokemon.Name).FirstOrDefault();

                var random = new Random();
                var randomIndex = random.Next(0, encounter.VersionDetails.Count);
                var versionDetail = encounter.VersionDetails[randomIndex];
                var level = versionDetail.encounterDetails.FirstOrDefault()?.MaxLevel;

                return new PokemonLocationEntity
                {
                    PokemonId = pokemon.PokemonIdentifier,
                    LocationId = location.LocationIdentifier,
                    MaxChance = versionDetail.MaxChance,
                    Level = (int)level
                };
            }

            return res;

            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error getting pokemon details");
            }
            return null;
        }

        public async Task<LocationEntity> GetLocationAreaAsync(int id)
        {
            try
            {
                var urlAux = $"pokemon/{id}/encounters";
                var encounters = await _client.GetAsync<List<EncounterApiDTO>>(urlAux);

                var random = new Random();
                var randomIndex = random.Next(0, encounters.Count);
                var locationAux = encounters[randomIndex].Location;

                return _mapper.Map<LocationEntity>(locationAux);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting location area");
            }
            return null;
        }

        public async Task<PokemonSpecieEntity> GetPokemonAsync(int id)
        {
            _logger.LogInformation("Getting pokemon");
            PokemonSpecieEntity pokemon = null;
            try
            {
                pokemon = await _redisCache.GetAsync<PokemonSpecieEntity>($"Pokemon:{id}");
                
                if(pokemon == null)
                {
                    var urlAux = $"pokemon/{id}";
                    var a = await _client.GetAsync<PokemonApiDTO>(urlAux);
                    pokemon = _mapper.Map<PokemonSpecieEntity>(a);
                    await _redisCache.SetAsync($"Pokemon:{id}", pokemon, TimeSpan.FromHours(1));

                }
            } catch (Exception ex) 
            {
                _logger.LogError(ex, "Error getting pokemon");
            }
            
            return pokemon;
        }
    }
}
