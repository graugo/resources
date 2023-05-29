using System.Collections.Generic;
using Ejercicio19_Subasta.Application.Contracts;
using Ejercicio19_Subasta.Application.InfrastructureContracts;
using Ejercicio19_Subasta.Domain.Models;

namespace Ejercicio19_Subasta.Application.Implementation
{
    public class AuctionService : IAuctionService
    {
        private readonly IPokemonRepository _pokeRepo;
        private readonly IBidRepository _auctionRepo;
      
        public AuctionService(IPokemonRepository pokemonRepo, IBidRepository auctionRepo)
        {
            _pokeRepo = pokemonRepo;
            _auctionRepo = auctionRepo;
        }


        public async Task<bool> Register()
        {
            
            Random random = new Random();
            int pokemonId = random.Next(1, 152);
            var pokemon = await _pokeRepo.GetPokemonAsync(pokemonId);
            var location = await _pokeRepo.GetLocationAreaAsync(pokemonId);
            var details = await _pokeRepo.GetDetailsAsync(pokemon, location);

            if (details == null) { return false; }

            await _auctionRepo.RegisterPoke(pokemon);
            await _auctionRepo.RegisterLocation(location);
            var id = await _auctionRepo.RegisterDetails(details);

            var auction = new AuctionEntity(pokemon, location, details, id);
            var auctionId = await _auctionRepo.RegisterAuction(auction, pokemon, location);
            auction.AuctionId = auctionId;

            var auctions = _auctionRepo.GetActualAuctions();
            auctions.Add(auction);
            _auctionRepo.SetAuctions(auctions);

            return true;
        }
    }
}

