using EX.First.Infrastructure.Contracts.Contracts;
using EX.First.Infrastructure.Impl.Cache;
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
    public class EmpireRepository : IEmpireRepository
    {
        private readonly IApiCaller _client;
        private readonly IInfrastructureConfiguration _config;
        private readonly ILog _log;
        private readonly IEmpireMapper _mapper;
        private readonly ICacheService _cacheService;

        public EmpireRepository(IApiCaller client, 
                                IInfrastructureConfiguration config, 
                                ILog log, 
                                IEmpireMapper mapper,
                                ICacheService cacheService)
        {
            _client = client;
            _config = config;
            _log = log;
            _mapper = mapper;
            _cacheService = cacheService;
        }

        public async Task<IEnumerable<PriceEntity>> GetPrices()
        {
            IEnumerable<PriceEntity> price = null;
            try
            {
                price = _cacheService.Get<IEnumerable<PriceEntity>>("PriceEntity");
                if (price == null)
                {
                    var priceDtos = await _client.GetAsync<IEnumerable<PriceDto>>($"{_config.EmpireUrl}prices.json");
                    price = _mapper.ToPriceEntityList(priceDtos);
                    _cacheService.Set("PriceEntity", price, new TimeSpan(0, 20, 0));
                }
            }
            catch (Exception e)
            {
                _log.Error(e.Message);
            }

            return price;
        }

        public async Task<IEnumerable<RebelInfluenceEntity>> GetRebelInfluence()
        {
            try
            {
                var rebelInfluenceDtos = await _client.GetAsync<IEnumerable<RebelInfluenceDto>>($"{_config.EmpireUrl}spyreport.json");
                var rebelInfluence = _mapper.ToRebelInfluenceEntityList(rebelInfluenceDtos);

                return rebelInfluence;
            }
            catch (Exception e)
            {
                _log.Error(e.Message);
            }

            return null;
        }
    }
}
