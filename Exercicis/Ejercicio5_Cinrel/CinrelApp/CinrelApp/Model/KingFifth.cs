using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinrelApp.Model
{
    internal class KingFifth : King, IKing
    {
        public KingFifth()
        {
            Name = "I the Fifth";
        }
        public void Abdicate()
        {
            Console.WriteLine($"{Name} abdicates");
        }

        public void PublicManagement()
        {
            Console.WriteLine($"{Name} sets a party");
        }

        public void TakeThrone()
        {
            Console.WriteLine($"{Name} takes Throne");
        }
    }
}
