using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderApp.Model.Builder
{
    internal class CarBuilder : IBuilder
    {
        private Car car = new Car();

        public void Reset()
        {
            car = new Car();
        }

        public void SetEngine(string engine)
        {
            car._engine = engine;
        }

        public void SetGPS()
        {
            car._gps = true;
        }

        public void SetSeats(int number)
        {
            car._seats = number;
        }

        public void SetTripComputer()
        {
            car._tripComputer = true;
        }

        public Car Build()
        {
            return car;
        }
    }
}
