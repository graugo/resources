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
    public class BidServiceTesting
    {
        private Mock<IBidRepository> _bidRepository;

        public BidServiceTesting()
        {
            _bidRepository = new Mock<IBidRepository>();
        }

        [Theory]
        [InlineData(1, 1590)]
        public void BidOnAuction_Ok(int id, int value)
        {
            _bidRepository.Setup(x => x.GetActualAuctions()).Returns(GetAuctions());

            var sut = new BidService(_bidRepository.Object);

            var result = sut.BidOnAuction(id, value);

            Assert.True(result);
        }

        [Theory]
        [InlineData(1, 100)]
        [InlineData(3, 12345)]
        public void BidOnAuction_Ko(int id, int value)
        {
            _bidRepository.Setup(x => x.GetActualAuctions()).Returns(GetAuctions());

            var sut = new BidService(_bidRepository.Object);

            var result = sut.BidOnAuction(id, value);

            Assert.False(result);
        }

        [Theory]
        [InlineData(1, 100)]
        public void BidOnAuction_WhenActuionsEmpty(int id, int value)
        {
            _bidRepository.Setup(x => x.GetActualAuctions()).Returns(new List<AuctionEntity>());

            var sut = new BidService(_bidRepository.Object);

            var result = sut.BidOnAuction(id, value);

            Assert.False(result);
        }

        [Theory]
        [InlineData(1)]
        public void GetAuctionById_Ok(int id)
        {
            _bidRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(GetAuctionById());

            var sut = new BidService(_bidRepository.Object);

            var result = sut.GetAuctionById(id);

            Assert.True(result.AuctionId == id);
        }

        [Theory]
        [InlineData(2)]
        public void GetAuctionById_Ko(int id)
        {
            _bidRepository.Setup(x => x.GetById(id)).Returns(() => null);

            var sut = new BidService(_bidRepository.Object);

            var result = sut.GetAuctionById(id);

            Assert.Null(result);
        }

        private AuctionEntity GetAuctionById()
        {
            return new AuctionEntity
            {
                AuctionId = 1,
                AuctionName = "Auction:1",
                EntryPrice = 123,
                ActualPrice = 123,
                PokemonLocationId = 1,
                NumberBid = 1,
                Created = DateTime.Now.TimeOfDay,
                IsShiny = true
            };
        }

        private List<AuctionEntity> GetAuctions()
        {
            return new List<AuctionEntity> {
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
