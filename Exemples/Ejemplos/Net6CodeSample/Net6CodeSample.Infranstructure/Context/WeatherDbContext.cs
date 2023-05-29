using Microsoft.EntityFrameworkCore;
using Net6CodeSample.Infranstructure.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net6CodeSample.Infranstructure.Context
{
    public class WeatherDbContext : DbContext
    {
        public WeatherDbContext(DbContextOptions<WeatherDbContext> options): base(options)
        {

        }

        public DbSet<WeatherForecastDto> WeatherForecasts { get; set;}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=WeatherForecastHistoric;Trusted_Connection=True");
        //}
    }
}
