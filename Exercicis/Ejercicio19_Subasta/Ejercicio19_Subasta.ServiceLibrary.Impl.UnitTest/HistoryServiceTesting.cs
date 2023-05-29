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
    public class HistoryServiceTesting
    {
        private Mock<IHistoryRepository> _historyRepository;

        public HistoryServiceTesting()
        {
            _historyRepository = new Mock<IHistoryRepository>();
        }

        [Fact]
        public void GetHistory_Ok()
        {
            _historyRepository.Setup(x => x.GetAuctionHistory()).Returns(GetHistory());

            var sut = new HistoryService(_historyRepository.Object);

            var result = sut.GetHistory();

            Assert.True(result.Count == 2);
        }

        [Fact]
        public void GetHistory_WhenHistoryIsNull()
        {
            _historyRepository.Setup(x => x.GetAuctionHistory()).Returns(() => null);

            var sut = new HistoryService(_historyRepository.Object);

            var result = sut.GetHistory();

            Assert.Null(result);
        }

        [Fact]
        public void GetHistory_WhenHistoryIsEmpty()
        {
            _historyRepository.Setup(x => x.GetAuctionHistory()).Returns(new List<AuctionEntity>());

            var sut = new HistoryService(_historyRepository.Object);

            var result = sut.GetHistory();

            Assert.True(result.Count == 0);
            Assert.Empty(result);
        }

        private List<AuctionEntity> GetHistory()
        {
            return new List<AuctionEntity>
            {
                new AuctionEntity
                {
                    AuctionId = 1,
                    AuctionName = "Auction:1",
                    EntryPrice = 123,
                    ActualPrice = 123,
                    PokemonLocationId = 1,
                    NumberBid = 1,
                    Created = DateTime.Now.TimeOfDay,
                    IsShiny = true
                },
                new AuctionEntity
                {
                    AuctionId = 2,
                    AuctionName = "Auction:2",
                    EntryPrice = 123,
                    ActualPrice = 123,
                    PokemonLocationId = 1,
                    NumberBid = 1,
                    Created = DateTime.Now.TimeOfDay,
                    IsShiny = true
                }
            };
        }
    }
}
