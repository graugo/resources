using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.OCP
{
    internal class OCP1 : OCP
    {
        public override int operation() 
        {
            return base.operation() + 3; 
        }
    }
}
