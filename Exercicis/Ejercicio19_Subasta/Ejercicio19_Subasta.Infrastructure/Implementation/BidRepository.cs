using AutoMapper;
using Ejercicio19_Subasta.Application.InfrastructureContracts;
using Ejercicio19_Subasta.CrossCutting.Cache;
using Ejercicio19_Subasta.Domain.Models;
using Ejercicio19_Subasta.Infrastructure.Context;
using Ejercicio19_Subasta.Infrastructure.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Runtime.Intrinsics.X86;

namespace Ejercicio19_Subasta.Infrastructure.Implementation
{
    public class BidRepository : IBidRepository
    {
        private readonly ICacheService _cacheService;
        private readonly AuctionDBContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<BidRepository> _logger;

        public BidRepository(ICacheService cacheService, AuctionDBContext auctionDBContext, IMapper mapper, ILogger<BidRepository> logger)
        {
            _cacheService = cacheService;
            _context = auctionDBContext;
            _mapper = mapper;
            _logger = logger;
        }
        public List<AuctionEntity> GetActualAuctions()
        {
            _logger.LogInformation("Getting actual auctions");
            try
            {
            var auctions = _mapper.Map<List<AuctionEntity>>(_cacheService.GetAsync<List<AuctionDTO>>(CacheKeys.Auctions));
            return auctions;

            }catch(Exception ex)
            {
                _logger.LogError(ex, "Error getting actual auctions");
            }
            return default;
        }
        public void SetAuctions(List<AuctionEntity> auctions)
        {
            _logger.LogInformation("Setting auctions");
            try
            {
            _cacheService.SetAsync<List<AuctionDTO>>(CacheKeys.Auctions, _mapper.Map<List<AuctionDTO>>(auctions), new TimeSpan(1, 0, 0));

            }catch(Exception ex)
            {
                _logger.LogError(ex, "Error setting auctions");
            }
        }

        public AuctionEntity GetById(int id)
        {
            _logger.LogInformation($"{nameof(GetById)}");
            try
            {
            //var auction = _context.Auctions.Where(x => x.AuctionId == id).FirstOrDefault();
            var auction = _cacheService.GetAsync<List<AuctionDTO>>(CacheKeys.Auctions).FirstOrDefault(a => a.AuctionId == id);
            return _mapper.Map<AuctionEntity>(auction);

            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error getting auction by id");
            }
            return default;
        }

        public async Task<int> RegisterAuction(AuctionEntity auction, PokemonSpecieEntity pokemon, LocationEntity location)
        {
            _logger.LogInformation($"{nameof(RegisterAuction)}");
            try
            {
                var auctionDto = _mapper.Map<AuctionDTO>(auction);
                await _context.Auctions.AddAsync(auctionDto);
                await _context.SaveChangesAsync();
                return _context.Auctions.Entry(auctionDto).CurrentValues.GetValue<int>("AuctionId");
            } catch (Exception ex) 
            {
                
                _logger.LogError(ex, "Error registering auction");
               
            };
            return -1;
        }

        public async Task<int> RegisterDetails(PokemonLocationEntity details)
        {
            _logger.LogInformation($"{nameof(RegisterDetails)}");
            try
            {
                var pokeDTO = _mapper.Map<PokemonLocationDTO>(details);
                await _context.PokemonLocation.AddAsync(pokeDTO);
                await _context.SaveChangesAsync();
                int id = _context.PokemonLocation.Entry(pokeDTO).CurrentValues.GetValue<int>("Id");
                return id;
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex, "Error registering details");
            };
            return -1;
        }

        public async Task RegisterLocation(LocationEntity location)
        {
            _logger.LogInformation($"{nameof(RegisterLocation)}");
            try
            {
                if (!_context.Locations.Any(x => x.LocationIdentifier == location.LocationIdentifier))
                {
                    await _context.Locations.AddAsync(_mapper.Map<LocationDTO>(location));
                    await _context.SaveChangesAsync();
                }                
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex, "Error registering location");
            }
        }

        public async Task RegisterPoke(PokemonSpecieEntity pokemon)
        {
            _logger.LogInformation($"{nameof(RegisterPoke)}");
            try
            {
                if (!_context.Pokemon.Any(x => x.PokemonIdentifier == pokemon.PokemonIdentifier)) {
                    await _context.Pokemon.AddAsync(_mapper.Map<PokemonSpecieDTO>(pokemon));
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex, "Error registering pokemon");
            };
        }

        public async Task SaveAuction(AuctionEntity a)
        {
            _logger.LogInformation($"{nameof(SaveAuction)}");
            try
            {
            var aux = _context.Auctions.Where(x => x.AuctionId == a.AuctionId).FirstOrDefault();

            if (aux != null)
                {
                    var auctionDto = _mapper.Map<AuctionDTO>(a);
                    _context.Attach(aux);
                    aux.ActualPrice = a.ActualPrice;
                    aux.NumberBid = a.NumberBid;
                    await _context.SaveChangesAsync();
                }         
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error saving auction");
            }
        }

        public void UpdateCache(List<AuctionEntity> result)
        {
            try
            {
            _cacheService.SetAsync<List<AuctionDTO>>(CacheKeys.Auctions, 
                _mapper.Map<List<AuctionDTO>>(result),
                new TimeSpan(1, 0, 0));

            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error updating cache");
            }
        }

        public async Task SaveTransaction(TransactionEntity transactionEntity)
        {
            try
            {
                await _context.Transactions.AddAsync(_mapper.Map<TransactionDTO>(transactionEntity));
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            { 
                _logger.LogError($"Failed to save transaction: {ex}");
            }
        }
    }
}
