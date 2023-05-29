using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Encapsulacion
{
    internal class Encapsulacion
    {
        public Encapsulacion(int i) { interger = i; }
        private int interger = 0;

        public int Interger { get { return interger; } }

        public int calc { get { return method1(); } }

        private int method1() { return interger*2; }
    }
}
