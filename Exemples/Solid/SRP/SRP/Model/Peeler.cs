namespace SRP.Model
{
    internal class Peeler : IngredientProcessor
    {
        public Peeler() { }
        public override void Process(string ingredient)
        {
            Console.WriteLine("Peeling {0}", ingredient);
        }
    }
}
