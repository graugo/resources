using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyborgApp.Model.Decorators
{
    internal class SteelDecorator : BaseArmDecorator
    {
        public SteelDecorator(IExtremity extremity) : base(extremity)
        {
        }

        public override void Move()
        {
            
            Console.WriteLine("Steel protection activated");
            base.Move();
        }
    }
}
