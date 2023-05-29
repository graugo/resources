using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Abstraccion
{
    internal abstract class Abstraccion
    {
        public abstract int Id { get; set; }

        public abstract int method1();

        public virtual int method2() { return 0; }
    }
}
