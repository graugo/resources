using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Herencia
{
    internal class Base
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int method1() { return 1; }

        public virtual int method2() { return 2; }
    }
}
