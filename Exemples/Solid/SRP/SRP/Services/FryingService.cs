using SRP.Model;

namespace SRP.Services
{
    internal class FryingService
    {
        IngredientProcessor Fryer => new Fryer();

        public FryingService() { }

        public void Fry(string ingredient) { Fryer.Process(ingredient); }
    }
}
