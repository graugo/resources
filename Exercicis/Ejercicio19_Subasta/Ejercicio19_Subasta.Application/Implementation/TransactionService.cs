using Ejercicio19_Subasta.Application.Contracts;
using Ejercicio19_Subasta.Application.InfrastructureContracts;
using Ejercicio19_Subasta.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio19_Subasta.Application.Implementation
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _repository;

        public TransactionService(ITransactionRepository repository)
        {
            _repository = repository;
        }

        public List<TransactionEntity> GetTransactionsByAuctionId(int auctionId)
        {
            var result = _repository.GetTransactionsByAuctionId(auctionId);
            return result;
        }
    }
}
