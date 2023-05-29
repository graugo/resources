namespace OCP_exercise.Model
{
    internal abstract class PlanetSystem
    {
        protected string? _name;
        public string? Name { get => _name; protected set => _name = value; }
        protected decimal _valueCoin;
        public decimal ValueCoin { get => _valueCoin; protected set => _valueCoin = value; }
        public bool IsClosed { get; protected set; }

        public abstract void Analyze(Component c);
    }
}
