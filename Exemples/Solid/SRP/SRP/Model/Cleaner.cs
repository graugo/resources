namespace SRP.Model
{
    internal class Cleaner : IngredientProcessor
    {
        public Cleaner() { }
        public override void Process(string ingredient)
        {
            Console.WriteLine("Cleaning {0}", ingredient);
        }
    }
}
