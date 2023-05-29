using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio19_Subasta.Domain.Models
{
    public class AuctionEntity
    {
        public AuctionEntity(PokemonSpecieEntity pokemon, LocationEntity location, PokemonLocationEntity details, int id) 
        {
            AuctionName = "Auction:" + pokemon.Name;
            PokemonLocationId = id;
            IsShiny = Random.Shared.Next(1, 64) == 1;
            int pAux = (pokemon.Weight * pokemon.Height) + details.Level * (details.MaxChance + location.LocationIdentifier);
            EntryPrice = IsShiny ? pAux * 20 : pAux;
            ActualPrice = EntryPrice;
            Created = DateTime.Now.TimeOfDay;
        }

        public AuctionEntity()
        {
            
        }

        public int AuctionId { get; set; }
        public string AuctionName { get; set;}
        public decimal EntryPrice { get; set; }
        public decimal ActualPrice { get; set; }
        public int PokemonLocationId { get; set; }
        public int NumberBid { get; set; }
        public TimeSpan Created { get; set; }
        public bool IsShiny { get; set; }
    }
}
