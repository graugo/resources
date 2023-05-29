using Ejercicio19_Subasta.Application.InfrastructureContracts;
using Ejercicio19_Subasta.Domain.Models;
using Ejercicio19_Subasta.Infrastructure.IntegrationTest.IOC;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Ejercicio19_Subasta.Infrastructure.IntegrationTest
{
    public class CacheAndDbCallsTesting
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IBidRepository _sut;
        public CacheAndDbCallsTesting()
        {
            var services = InfrastructureTestingModule.AddInfrastructureTestingModule();
            _serviceProvider = services.BuildServiceProvider();
            _sut = _serviceProvider.GetService<IBidRepository>();
            SetTestData();
        }

        //List<AuctionEntity> GetActualAuctions();
        //void UpdateCache(List<AuctionEntity> result);
        [Fact]
        public void UpdateCacheAndGetActualAuctions_Ok()
        {
            var auction = new AuctionEntity
            {
                AuctionId = 1,
                ActualPrice = 1,
                Created = DateTime.Now.TimeOfDay,
                AuctionName = "Test_SaveAuction",
                EntryPrice = 1,
                IsShiny = true,
                NumberBid = 1,
                PokemonLocationId = 1
            };
            _sut.UpdateCache(new List<AuctionEntity> { auction });
            var auctions = _sut.GetActualAuctions();
            Assert.NotNull(auctions);
            Assert.Equal(1, auctions.Count);
            Assert.Equivalent(auction, auctions.FirstOrDefault());
        }

        //Task SaveAuction(AuctionEntity a);
        //Task<int> RegisterAuction(AuctionEntity auction, PokemonSpecieEntity pokemon, LocationEntity location);
        //Task RegisterPoke(PokemonSpecieEntity pokemon);
        //Task RegisterLocation(LocationEntity location);
        //Task<int> RegisterDetails(PokemonLocationEntity details);
        [Fact]
        public async Task RegisterAndSaveAuctionAndTransaction_Ok()
        {
            var auction = new AuctionEntity
            {
                ActualPrice = 1,
                Created = DateTime.Now.TimeOfDay,
                AuctionName = "Test_SaveAuction",
                EntryPrice = 1,
                IsShiny = true,
                NumberBid = 1,
                PokemonLocationId = 1
            };
            var pokemonSpecie = new PokemonSpecieEntity
            {
                PokemonIdentifier = 1,
                Name = "Test_Location"
            };
            var location = new LocationEntity
            {
                URL = "http:/1/",
                Name = "Test_Location"
            };
            var details = new PokemonLocationEntity
            {
                PokemonId = 1,
                LocationId = 1,
            };
            await _sut.RegisterPoke(pokemonSpecie);
            await _sut.RegisterLocation(location);
            await _sut.RegisterDetails(details);
            await _sut.RegisterAuction(auction, pokemonSpecie, location);
            await _sut.SaveAuction(auction);

            var transaction = new TransactionEntity
            {
                AuctionId = 1,
                FinalValue = 2,
                OriginalValue = 1,
                Increment = 1,
            };
            await _sut.SaveTransaction(transaction);

            var historyRepository = _serviceProvider.GetService<IHistoryRepository>();
            var auctions = historyRepository.GetAuctionHistory();
            var auctionRetrieved = auctions.FirstOrDefault(a => a.Created == auction.Created);

            var transactionRepository = _serviceProvider.GetService<ITransactionRepository>();
            var transactions = transactionRepository.GetTransactionsByAuctionId(1);
            var transactionRetrieved = transactions.FirstOrDefault(t => t.AuctionId == transaction.AuctionId);

            Assert.NotNull(auctions);
            Assert.Equal(auction.ActualPrice, auctionRetrieved.ActualPrice);
            Assert.Equal(auction.AuctionName, auctionRetrieved.AuctionName);
            Assert.Equal(auction.Created, auctionRetrieved.Created);
            Assert.Equal(auction.EntryPrice, auctionRetrieved.EntryPrice);
            Assert.Equal(auction.IsShiny, auctionRetrieved.IsShiny);
            Assert.Equal(auction.NumberBid, auctionRetrieved.NumberBid);
            Assert.Equal(auction.PokemonLocationId, auctionRetrieved.PokemonLocationId);
            
            Assert.NotNull(transactions);
            Assert.Equal(transaction.AuctionId, transactionRetrieved.AuctionId);
            Assert.Equal(transaction.FinalValue, transactionRetrieved.FinalValue);
            Assert.Equal(transaction.OriginalValue, transactionRetrieved.OriginalValue);
            Assert.Equal(transaction.Increment, transactionRetrieved.Increment);
        }

        //AuctionEntity GetById(int id);
        [Fact]
        public async Task GetById_Ok()
        {
            var auction = new AuctionEntity
            {
                ActualPrice = 1,
                Created = DateTime.Now.TimeOfDay,
                AuctionName = "Test_SaveAuction",
                EntryPrice = 1,
                IsShiny = true,
                NumberBid = 1,
                PokemonLocationId = 1
            };
            _sut.UpdateCache(new List<AuctionEntity> { auction });
            var auctionRetrieved = _sut.GetById(auction.AuctionId);
            Assert.NotNull(auctionRetrieved);
            Assert.Equal(auction.ActualPrice, auctionRetrieved.ActualPrice);
            Assert.Equal(auction.AuctionName, auctionRetrieved.AuctionName);
            Assert.Equal(auction.Created, auctionRetrieved.Created);
            Assert.Equal(auction.EntryPrice, auctionRetrieved.EntryPrice);
            Assert.Equal(auction.IsShiny, auctionRetrieved.IsShiny);
            Assert.Equal(auction.NumberBid, auctionRetrieved.NumberBid);
            Assert.Equal(auction.PokemonLocationId, auctionRetrieved.PokemonLocationId);
        }
        //List<AuctionEntity> GetActualAuctions();
        //void SetAuctions(List<AuctionEntity> auctions);
        [Fact]
        public void SetAuctionsAndGetActualAuctions_Ok()
        {
            var auction = new AuctionEntity
            {
                AuctionId = 1,
                ActualPrice = 1,
                Created = DateTime.Now.TimeOfDay,
                AuctionName = "Test_SaveAuction",
                EntryPrice = 1,
                IsShiny = true,
                NumberBid = 1,
                PokemonLocationId = 1
            };
            _sut.SetAuctions(new List<AuctionEntity> { auction });
            var auctions = _sut.GetActualAuctions();
            Assert.NotNull(auctions);
            Assert.Equal(1, auctions.Count);
            Assert.Equivalent(auction, auctions.FirstOrDefault());
        }
        private int SetTestData()
        {
            var result = 0;
  
            string executionPath = AppContext.BaseDirectory;

            string scriptPath = "../../../Scripts/CleanDatabase.sql";
            if (File.Exists(scriptPath))
            {
                using (SqlConnection conn = new SqlConnection("Data Source =(localdb)\\MSSQLLocalDB; Initial Catalog = AuctionDB;Integrated Security=True;"))
                {
                    conn.Open(); 
                    string script = File.ReadAllText(scriptPath);
                    SqlCommand command = new SqlCommand(script, conn);
                    result = command.ExecuteNonQuery();
                }
            }
            return result;
        }
    }
}