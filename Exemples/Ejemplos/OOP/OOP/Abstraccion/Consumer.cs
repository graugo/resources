using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Abstraccion
{
    internal class Consumer : Abstraccion
    {
        public override int Id { get; set; }

        public override int method1()
        {
            throw new NotImplementedException();
        }

        public override int method2() { return Id; }
    }
}
