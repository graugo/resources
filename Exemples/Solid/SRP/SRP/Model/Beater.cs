namespace SRP.Model
{
    internal class Beater : IngredientProcessor
    {
        public Beater() { }
        public override void Process(string ingredient)
        {
            Console.WriteLine("Beating {0}", ingredient);
        }
    }
}
