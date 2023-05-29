using AutoMapper;
using CrossingApp.Application.ContractsInfra;
using CrossingApp.CrossCutting.Cache;
using CrossingApp.Domain.Models;
using CrossingApp.Infrastructure.Callers;
using CrossingApp.Infrastructure.Context;
using CrossingApp.Infrastructure.Models.Config;
using CrossingApp.Infrastructure.Models.Deserialize;
using CrossingApp.Infrastructure.Models.DTO;
using Microsoft.Extensions.Options;
using Serilog;
namespace CrossingApp.Infrastructure.Repository
{
    public class CharacterRepo : ICharacterRepo
    {
        private readonly ILogger _logger;
        private readonly CrossingContext _context;
        private readonly IMapper _mapper;
        private readonly ICrossingCache _cache;
        private readonly URLConfig _urlConfig;
        private readonly ITypedHttpClient _client;
        public CharacterRepo(ILogger logger,
                             CrossingContext context, 
                             IMapper mapper, 
                             ICrossingCache cache, 
                             IOptions<URLConfig> urlOptions,
                             ITypedHttpClient client)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
            _cache = cache;
            _urlConfig = urlOptions.Value;
            _client = client;
        }
        
        public async Task<CharacterEntity> GetCharacter(int id)
        {
            _logger.Information("Retrieve Data");
            var str = String.Format(_urlConfig.Characters, id);
            var res = await  _client.GetAsync<CharacterDeserialize>(str);
            var dto = _mapper.Map<CharacterDTO>(res);
            // var res =  _context.Characters.Where(x => x.Id == id).FirstOrDefault();
            await _cache.SetAsync<CharacterDTO>($"Character:{res.Id}", dto, TimeSpan.FromMinutes(20));
            return _mapper.Map<CharacterEntity>(dto);
        }
    }
}
