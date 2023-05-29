using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCP_exercise.Model
{
    internal class ClosedSystem : PlanetSystem
    {
        public ClosedSystem(string name)
        {
            Name = name;
            IsClosed = true;
        }
        public ClosedSystem(string name, decimal systemCoin)
        {
            Name = name;
            IsClosed = true;
            ValueCoin = systemCoin;
        }
        public override void Analyze(Component c)
        {
            Console.WriteLine($"{Name}: {c.Description}");
        }
    }
}
