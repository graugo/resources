using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinrelApp.Model
{
    internal class KingNinth : King, IKing
    {
        public KingNinth()
        {
            Name = "I the Ninth";
        }
        public void Abdicate()
        {
            Console.WriteLine($"{Name} abdicates");
        }

        public void PublicManagement()
        {
            Console.WriteLine($"{Name} sets a democracy");
        }

        public void TakeThrone()
        {
            Console.WriteLine($"{Name} takes the throne");
        }
    }
}
