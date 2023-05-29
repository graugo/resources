using Ejercicio19_Subasta.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio19_Subasta.Application.InfrastructureContracts
{
    public interface IBidRepository
    {
        List<AuctionEntity> GetActualAuctions();
        Task SaveAuction(AuctionEntity a);
        void UpdateCache(List<AuctionEntity> result);
        AuctionEntity GetById(int id);
        Task RegisterPoke(PokemonSpecieEntity pokemon);
        Task RegisterLocation(LocationEntity location);
        Task<int> RegisterDetails(PokemonLocationEntity details);
        Task<int> RegisterAuction(AuctionEntity auction, PokemonSpecieEntity pokemon, LocationEntity location);
        void SetAuctions(List<AuctionEntity> auctions);
        Task SaveTransaction(TransactionEntity transactionEntity);
    }
}
