using Exam.RouteApp.Infrastructure.Contracts.Contracts;
using Exam.RouteApp.Infrastructure.Impl.Cache;
using Exam.RouteApp.Infrastructure.Impl.Caller;
using Exam.RouteApp.Infrastructure.Impl.Config;
using Exam.RouteApp.Infrastructure.Impl.Mapper;
using Exam.RouteApp.Infrastructure.Impl.Models;
using Exam.RouteApp.Library.Models;
using log4net;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Exam.RouteApp.Infrastructure.Impl.Implementations
{
    public class RouteRepository : IRouteRepository
    {
        private readonly IApiCaller _apiCaller;
        private readonly IRepoConfig _repoConfig;
        private readonly IRepoMapper _repoMapper;
        private readonly IRepoCache _repoCache;
        private readonly ILog _log;

        public RouteRepository(IApiCaller apiCaller, 
                               IRepoConfig repoConfig, 
                               IRepoMapper repoMapper, 
                               ILog log,
                               IRepoCache repoCache)
        {
            _apiCaller = apiCaller;
            _repoConfig = repoConfig;
            _repoMapper = repoMapper;
            _log = log;
            _repoCache = repoCache;
        }
        public async Task<List<PlanetEntity>> GetPlanetsAsync()
        {
            List<PlanetEntity> result = null;
            
            try
            {
                List<PlanetDTO> list = null;
                if (_repoCache.Planets != null && _repoCache.Planets.Count > 0)
                    list = _repoCache.Planets;
                else
                    list = await _apiCaller.GetAsync<List<PlanetDTO>>($"{_repoConfig.SindicateApiUrl}planets.json");
                if (list == null)
                    return null;

                var dict = await GetDistances();
                var influenceDict = await GetInfluences();
                
                result = _repoMapper.ToPlanetEntitylist(list.Select(x=> AssignInfluence(AssignDistances(x, dict),influenceDict)).ToList());
                _repoCache.SetPlanets(list);
            }catch (Exception ex)
            {
                _log.Error(ex.Message);
            }
            
            return result;
        }
        private async Task<Dictionary<string,List<PseudoDistanceDTO>>> GetDistances()
        {
            Dictionary<string,List<PseudoDistanceDTO>> result = null;
            result = await _apiCaller.GetAsync<Dictionary<string, List<PseudoDistanceDTO>>>($"{_repoConfig.SindicateApiUrl}distances.json");
            return result;
        }
        private async Task<List<InfluenceDTO>> GetInfluences()
        {
            List<InfluenceDTO> result = null;
            result = await _apiCaller.GetAsync<List<InfluenceDTO>>($"{_repoConfig.EmpireApiUrl}spyreport.json");
            return result;
        }
        private PlanetDTO AssignDistances(PlanetDTO dto, Dictionary<string,List<PseudoDistanceDTO>> dict)
        {
            PlanetDTO result = null;
            if (dto.Distances != null)
                return dto;
            if (dict != null)
            {
                dto.Distances = dict[dto.Code].ToList();
                result = dto;
            }
            return result;
        }
        private PlanetDTO AssignInfluence(PlanetDTO dto, List<InfluenceDTO> list)
        {
            PlanetDTO result = null;
            if (dto.Influence != 0)
                return dto;
            if (list != null)
            {
                dto.Influence = list.FirstOrDefault(x => dto.Code == x.Code).RebelInfluence;
                result = dto;
            }
            return result;
        }
        public async Task<PriceEntity> GetPriceAsync(string origin, string destination)
        {
            PriceDTO result = null;
            try
            {
                var basePrice = 0D;
                if (_repoCache.BasePrice > 0)
                    basePrice = _repoCache.BasePrice;
                else
                {
                    var aux = await _apiCaller.GetAsync<JObject[]>($"{_repoConfig.EmpireApiUrl}prices.json");
                    var jAux = aux[0].Property("pricesPerLunarDay").Value.ToString();

                    Double.TryParse(jAux, out basePrice);

                }
                if (basePrice > 0)
                {
                    var list = await GetPlanetsAsync();
                    var originDto = list.FirstOrDefault(x => x.Code.Equals(origin));
                    var destinationDto = list.FirstOrDefault(x => x.Code.Equals(destination));
                    if (originDto.Distances.Any(x => x.Code.Equals(destination)))
                    {
                        return CalculatePrice(originDto, destinationDto, basePrice);
                    }

                    
                    if (destinationDto.Distances.Any(x => x.Code.Equals(origin)))
                    {
                        return CalculatePrice(destinationDto, originDto, basePrice);
                    }
                }
                    
            } catch (Exception ex)
            {
                _log.Error(ex.Message);
            }
            return null;
        }
        private PriceEntity CalculatePrice(PlanetEntity origin, PlanetEntity destination, double basePrice)
        {
            var days = origin.Distances.FirstOrDefault(x => x.Code.Equals(destination.Code)).LunarYears * 365;
            var postTaxAmount = basePrice * (1 + (double)origin.RebellInfluence / 100D)  * (1 + (double)destination.RebellInfluence / 100D);
            var eliteTax = 0D;
            if (origin.RebellInfluence + destination.RebellInfluence > 40) 
                eliteTax = origin.RebellInfluence + destination.RebellInfluence - 40;
            var result = new PriceDTO
            {
                TotalAmount = postTaxAmount * (1 + eliteTax/100) * days,
                PricesPerLunarDay = basePrice,
                Taxes = new TaxesDTO
                {
                    OriginDefenseCost = basePrice * ((double)origin.RebellInfluence / 100D),
                    DestinationDefenseCost = basePrice * ((double)destination.RebellInfluence / 100D),
                    EliteDefenseCost = eliteTax / 100D
                }
            };
            return _repoMapper.ToPriceEntity(result);
        }
    }
}
