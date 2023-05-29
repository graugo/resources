using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyborgApp.Model.Singleton
{
    internal class Head : IExtremity
    {
        private static Head _instance;
        private Head() { }

        public static Head GetInstance()
        {
            if (_instance == null) _instance = new Head();
            return _instance;
        }
        public void Move()
        {
            Console.WriteLine("Moving Head");
        }
    }
}
