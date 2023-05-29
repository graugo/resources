using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyborgApp.Model
{
    internal class Leg : IExtremity
    {
        public virtual void Move()
        {
            Console.WriteLine("Moving Leg");
        }
    }
}
