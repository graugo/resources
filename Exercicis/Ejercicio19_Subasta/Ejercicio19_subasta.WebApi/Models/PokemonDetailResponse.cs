using Ejercicio19_Subasta.Domain.Models;

namespace Ejercicio19_subasta.WebApi.Models
{
    public class PokemonDetailResponse
    {
        public int Weight { get; set; }
        public int Height { get; set; }
        public int PokemonLocationId { get; set; }
        public int MaxChance { get; set; }
        public string AuctionName { get; set; }
        public decimal EntryPrice { get; set; }
        public decimal ActualPrice { get; set; }
        public int NumberBid { get; set; }


        public PokemonDetailResponse(PokemonSpecieEntity pokemon, LocationEntity location, PokemonLocationEntity details)
        {
            Weight = pokemon.Weight;
            Height = pokemon.Height;
            PokemonLocationId = location.LocationIdentifier;
            MaxChance = details.MaxChance;
            AuctionName = "Auction:" + pokemon.Name;
        }


    }

    
}
