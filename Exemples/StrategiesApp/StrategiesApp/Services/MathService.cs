using StrategiesApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategiesApp.Services
{
    internal class MathService
    {
        public MathService() {}
        public void Initialize()
        {
            Context context = new Context();
            int x;
            int y;
            string option;
            while (true)
            {
                string? data = Console.ReadLine();
                if (data == "exit") return;
            
                string[] dataSplit = data.Split(' ');
                if (Int32.TryParse(dataSplit[0], out x) && Int32.TryParse(dataSplit[dataSplit.Length -1], out y))
                {
                    option = dataSplit[1];
                    switch (option)
                    {
                        case "+":
                            context.SetStrategy(new AddStrategy());
                            break;
                        case "-":
                            context.SetStrategy(new SubtractStrategy());
                            break;
                        case "*":
                            context.SetStrategy(new MultiplyStrategy());
                            break;
                        default:
                            break;
                    }
                    Console.WriteLine(context.ExecuteStrategy(x, y));
                }   
            }
                     
        }
    }
}
