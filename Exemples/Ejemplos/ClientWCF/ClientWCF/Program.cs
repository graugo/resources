using System;
using ClientWCF.FirstWCFService;

namespace ClientWCF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Service1Client service = new Service1Client();
            CompositeType compositeType = new CompositeType 
            {
                BoolValue= true,
                StringValue = "adrian"
            };
            
            Console.WriteLine(service.GetData(1));
            Console.WriteLine(service.GetDataUsingDataContract(compositeType).StringValue);
            Console.ReadLine();
        }
    }
}
