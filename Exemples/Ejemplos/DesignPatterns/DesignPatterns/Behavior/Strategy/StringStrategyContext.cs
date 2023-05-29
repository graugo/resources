namespace DesignPatterns.Behravior.Strategy
{
    internal class StringStrategyContext
    {
        private IStringStrategy _stringStrategy;

        public void SetStrategy(IStringStrategy stringStrategy) 
        {
            _stringStrategy = stringStrategy;
        }

        public void Execute(string str) 
        {
            _stringStrategy.Execute(str);
        }
    }
}
