namespace OCP_exercise.Model
{
    internal class OpenSystem : PlanetSystem
    {
        public OpenSystem(string name)
        {
            Name = name;
            ValueCoin = 1;
            IsClosed = false;
        }
        public OpenSystem(string name, decimal systemCoin) 
        {
            Name = name;
            ValueCoin = systemCoin;
            IsClosed = false;
        }

        public override void Analyze(Component c)
        {
            Console.WriteLine($"{this.Name}: {c.BaseValue / ValueCoin} credits");
        }
    }
}
