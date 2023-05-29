using BuilderApp.Model.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderApp.Model
{
    internal class Director
    {
        public void BuildSportsCar(IBuilder builder)
        {
            builder.Reset();
            builder.SetSeats(2);
            builder.SetEngine("Sports Engine");
            builder.SetTripComputer();
            builder.SetGPS();
        }
    }
}
