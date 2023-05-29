using EX.First.Infrastructure.Contracts.Contracts;
using EX.First.Infrastructure.Impl.Caller;
using EX.First.Infrastructure.Impl.Configuration;
using EX.First.Infrastructure.Impl.Mappers;
using EX.First.Infrastructure.Impl.Models;
using EX.First.Library.Entities;
using log4net;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EX.First.Infrastructure.Impl.Implementations
{
    public class SindicateRepository : ISindicateRepository
    {
        private readonly IApiCaller _client;
        private readonly IInfrastructureConfiguration _config;
        private readonly ILog _log;
        private readonly ISindicateMapper _mapper;

        public SindicateRepository(IApiCaller client, 
                                   IInfrastructureConfiguration config,
                                   ISindicateMapper mapper,
                                   ILog log)
        {
            _client = client;
            _config = config;
            _mapper = mapper;
            _log = log;
        }

        public async Task<Dictionary<string, IEnumerable<DistanceEntity>>> GetDistances()
        {
            Dictionary<string, IEnumerable<DistanceEntity>> result = null;
            try
            {
                var distancesDto = await _client.GetAsync<Dictionary<string,IEnumerable<DistanceDto>>>($"{_config.SindicateUrl}distances.json");
                result = _mapper.ToDistancesDictionary(distancesDto);
            }
            catch (Exception e)
            {
                _log.Error(e.Message);
            }

            return result;
        }

        public async Task<IEnumerable<PlanetEntity>> GetPlanets()
        {
            IEnumerable<PlanetEntity> result = null;
            try
            {
                var planetsDto = await _client.GetAsync<List<PlanetDto>>($"{_config.SindicateUrl}planets.json");
                result = _mapper.ToPlanetEntityList(planetsDto);
            }
            catch (Exception e)
            {
                _log.Error(e.Message);
            }

            return result;

        }
    }
}
