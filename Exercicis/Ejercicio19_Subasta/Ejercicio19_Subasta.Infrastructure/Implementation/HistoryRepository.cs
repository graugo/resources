using AutoMapper;
using Ejercicio19_Subasta.Application.InfrastructureContracts;
using Ejercicio19_Subasta.Domain.Models;
using Ejercicio19_Subasta.Infrastructure.Context;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio19_Subasta.Infrastructure.Implementation
{
    public class HistoryRepository : IHistoryRepository
    {
        private readonly AuctionDBContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<HistoryRepository> _logger;

        public HistoryRepository(AuctionDBContext auctionDBContext, IMapper mapper, ILogger<HistoryRepository> logger)
        {
            _logger = logger;
            _context = auctionDBContext;
            _mapper = mapper;
        }

        public List<AuctionEntity> GetAuctionHistory()
        {
            try
            {
            return _context.Auctions.Select(x => _mapper.Map<AuctionEntity>(x)).ToList();

            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error getting auction history");
                return default;
            }
        }
    }
}
