using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeightConverter.Model;

namespace WeightConverter.Services
{
    internal class ConvertService
    {
        List<AbstractConverter> ConverterList;

        public ConvertService() 
        {
            ConverterList = new List<AbstractConverter>
            {
                new EarthConverter(),
                new MoonConverter(),
                new SaturnConverter()
            };

        }

        public void Initialize()
        {
            Console.WriteLine("Introduce mass:");
            string? mString = Console.ReadLine();
            if (String.IsNullOrEmpty(mString)) 
            {
                Console.WriteLine("No input written");
                return;
            }
            if (Decimal.TryParse(mString, out decimal d))
            {
                ConverterList.ForEach(x => Console.WriteLine(x.StringResult(d)));
            } else
                Console.WriteLine("Unable to parse decimal");
        }
    }
}
