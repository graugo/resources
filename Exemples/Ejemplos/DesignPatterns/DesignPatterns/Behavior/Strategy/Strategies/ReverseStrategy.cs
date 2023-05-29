namespace DesignPatterns.Behravior.Strategy.Strategies
{
    internal class ReverseStrategy : IStringStrategy
    {
        public void Execute(string str)
        {
            Console.WriteLine(str.Reverse().ToString());
        }
    }
}
