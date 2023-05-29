using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Net6CodeSample.Infranstructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net6CodeSample.Infrastructure.IntegrationTest.Fixture
{
    public class ServiceTestProvider
    {
        protected IServiceProvider Services { get; private set;}

        public void SetServices() 
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            serviceCollection.AddDbContext<WeatherDbContext>(
                options => options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=WeatherForecastHistoric;Trusted_Connection=True"));

            Services = serviceCollection.BuildServiceProvider();
        }
    }
}
