namespace DesignPatterns.Behravior.Strategy.Strategies
{
    internal class OrderedStrategy : IStringStrategy
    {
        public void Execute(string str)
        {
            Console.WriteLine(str.OrderBy(x => x).ToString());
        }
    }
}
