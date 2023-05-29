namespace ConsoleApp1.Model
{
    internal class Adder : Calculator
    {
        public override double Calculate(double x, double y)
        {
            return x + y;
        }
    }
}
