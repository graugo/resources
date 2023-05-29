using CrossingApp.Infrastructure.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace CrossingApp.Infrastructure.Context
{
    public class CrossingContext : DbContext
    {
        public CrossingContext(DbContextOptions<CrossingContext> options) : base(options){}

        public DbSet<CharacterDTO> Characters { get; set; }
    }
}
