using System.Security.Cryptography.X509Certificates;

namespace SRP.Model
{
    internal class Fryer : IngredientProcessor
    {
        public Fryer() { }
        public override void Process(string ingredient)
        {
            Console.WriteLine("Frying {0}", ingredient);
        }
    }
}
