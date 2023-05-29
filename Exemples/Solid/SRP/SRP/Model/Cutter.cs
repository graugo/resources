namespace SRP.Model
{
    internal class Cutter : IngredientProcessor
    {
        public Cutter() { }
        public override void Process(string ingredient)
        {
            Console.WriteLine("Cutting {0}", ingredient);
        }
    }
}
