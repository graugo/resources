using SRP.Model;

namespace SRP.Services
{
    internal class PreparingService
    {
        IngredientProcessor Peeler = new Peeler();
        IngredientProcessor Cleaner = new Cleaner();
        IngredientProcessor Cutter = new Cutter();
        IngredientProcessor Beater = new Beater();

        public PreparingService() {}

        public void Peel(string ingredient) { Peeler.Process(ingredient); }

        public void Clean(string ingredient) { Cleaner.Process(ingredient); }

        public void Cut (string ingredient) {  Cutter.Process(ingredient);}

        public void Beat(string ingredient) { Beater.Process(ingredient); }

        public string Combine (string ingredient1, string ingredient2)
        {
            return String.Format("{0} and {1}", ingredient1, ingredient2);
        }
    }
}
