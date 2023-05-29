using Ejercicio19_Subasta.Infrastructure.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio19_Subasta.Infrastructure.Context
{
    public class AuctionDBContext : DbContext
    {
        public AuctionDBContext(DbContextOptions<AuctionDBContext> auctions) : base(auctions)
        {
            
        }
        public DbSet<AuctionDTO> Auctions { get; set; }
        public DbSet<TransactionDTO> Transactions { get; set; }
        public DbSet<LocationDTO> Locations { get; set; }
        public DbSet<PokemonLocationDTO> PokemonLocation { get; set; }
        public DbSet<PokemonSpecieDTO> Pokemon { get; set; }
        public DbSet<HistoricDTO> Historic { get; set; }
    }
}
