using ConsoleApp1.Model;

namespace ConsoleApp1.Services
{
    internal class CalculateService
    {
        private Calculator Adder;
        private Calculator Subtractor;
        private Calculator Multiplier;
        private Calculator Divider;
        public CalculateService() 
        { 
            Adder = new Adder();
            Subtractor = new Subtractor();
            Multiplier = new Multiplier();
            Divider = new Divider();
        }

        public double Calculate(double x, double y, string op)
        {
            switch (op)
            {
                case "+": return Adder.Calculate(x, y);
                case "-": return Subtractor.Calculate(x, y);
                case "*": return Multiplier.Calculate(x, y);
                case "/": return Divider.Calculate(x, y);
                default: return 0;
            }
        }
    }
}
