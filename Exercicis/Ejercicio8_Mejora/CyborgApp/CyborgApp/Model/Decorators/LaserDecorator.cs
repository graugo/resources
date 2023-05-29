using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyborgApp.Model.Decorators
{
    internal class LaserDecorator : BaseArmDecorator
    {
        public LaserDecorator(IExtremity extremity) : base(extremity)
        {
        }
        public override void Move()
        {
            
            Console.WriteLine("LED lights turned on.");
            base.Move();
        }
    }
}
