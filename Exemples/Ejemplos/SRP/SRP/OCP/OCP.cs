using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.OCP
{
    internal class OCP
    {
        public virtual int operation() 
        {
            return 3 + 3;
        }

        public int operation1() 
        {
            return operation() + 5;
        }
    }
}
