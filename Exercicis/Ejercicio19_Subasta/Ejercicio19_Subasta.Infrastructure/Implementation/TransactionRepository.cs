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
    public class TransactionRepository : ITransactionRepository
    {
        private readonly AuctionDBContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<TransactionRepository> _logger;

        public TransactionRepository(AuctionDBContext context, IMapper mapper, ILogger<TransactionRepository> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public List<TransactionEntity> GetTransactionsByAuctionId(int auctionId)
        {
            try
            {
                var result = _context.Transactions.Where(t => t.AuctionId == auctionId).ToList();
                return _mapper.Map<List<TransactionEntity>>(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting transactions from database");
            }
            return null;
        }
    }
}
