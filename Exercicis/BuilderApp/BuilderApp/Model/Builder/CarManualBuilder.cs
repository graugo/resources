using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderApp.Model.Builder
{
    internal class CarManualBuilder : IBuilder
    {
        private Manual manual = new Manual();
        public void Reset()
        {
            manual = new Manual();
        }

        public void SetEngine(string engine)
        {
            manual._engine = engine;
        }

        public void SetGPS()
        {
            manual._gps = true;
        }

        public void SetSeats(int number)
        {
            manual._seats = number;
        }

        public void SetTripComputer()
        {
            manual._tripComputer = true;
        }

        public Manual Build()
        {
            return manual;
        }
    }
}
