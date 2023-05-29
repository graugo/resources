using Ejercicio19_Subasta.Application.Implementation;
using Ejercicio19_Subasta.Application.InfrastructureContracts;
using Ejercicio19_Subasta.Domain.Models;
using Ejercicio19_Subasta.Infrastructure.Implementation;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio19_Subasta.ServiceLibrary.Impl.UnitTest
{
    public class TransactionServiceTesting
    {
        private Mock<ITransactionRepository> _transactionrepository;

        public TransactionServiceTesting()
        {
            _transactionrepository = new Mock<ITransactionRepository>();
        }

        [Theory]
        [InlineData(1)]
        public void GetTransactionsByAuctionId_Ok(int id)
        {
            _transactionrepository.Setup(x => x.GetTransactionsByAuctionId(id)).Returns(GetTransactions());

            var sut = new TransactionService(_transactionrepository.Object);

            var result = sut.GetTransactionsByAuctionId(id);

            Assert.True(result.Count == 2);
        }

        [Theory]
        [InlineData(1)]
        public void GetTransactionsByAuctionId_Ko(int id)
        {
            _transactionrepository.Setup(x => x.GetTransactionsByAuctionId(id)).Returns(() => null);

            var sut = new TransactionService(_transactionrepository.Object);

            var result = sut.GetTransactionsByAuctionId(id);

            Assert.Null(result);
        }

        [Theory]
        [InlineData(1)]
        public void GetTransactionsByAuctionId_WhenReturnsEmptyList(int id)
        {
            _transactionrepository.Setup(x => x.GetTransactionsByAuctionId(id)).Returns(new List<TransactionEntity>());

            var sut = new TransactionService(_transactionrepository.Object);

            var result = sut.GetTransactionsByAuctionId(id);

            Assert.Empty(result);
        }

        private List<TransactionEntity> GetTransactions()
        {
            return new List<TransactionEntity>
            {
                new TransactionEntity
                {
                    Id = 1,
                    OriginalValue = 1,
                    Increment = 1,
                    FinalValue = 1,
                    AuctionId = 1
                },
                new TransactionEntity
                {
                    Id = 1,
                    OriginalValue = 1,
                    Increment = 1,
                    FinalValue = 1,
                    AuctionId = 1
                }
            };
        }
    }
}
