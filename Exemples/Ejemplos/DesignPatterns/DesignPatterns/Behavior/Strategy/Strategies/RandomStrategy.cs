namespace DesignPatterns.Behravior.Strategy.Strategies
{
    internal class RandomStrategy : IStringStrategy
    {
        public void Execute(string str)
        {
            Console.WriteLine(str.Replace('a', 'i'));
        }
    }
}
