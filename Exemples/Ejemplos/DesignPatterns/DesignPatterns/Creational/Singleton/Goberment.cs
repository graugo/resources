namespace DesignPatterns.Creational.Singleton
{
    internal class Goberment
    {
        private static Goberment _goberment;
        private string name;

        private Goberment(string name)
        {
            this.name = name;
        }

        public static Goberment Instance()
        {
            if (_goberment == null)
            {
                _goberment = new Goberment("pepe");
            }

            return _goberment;
        }
    }
}
