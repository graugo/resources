using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Variable
{
    internal class Foo<T> : IFoo<T>
    {
        public static string str = "";
        public static bool method1() { return true; }

        T IFoo<T>.Foo()
        {
            return typeof(T);
        }
    }
}
