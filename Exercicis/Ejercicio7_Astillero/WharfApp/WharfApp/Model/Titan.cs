using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WharfApp.Model
{
    internal sealed class Titan : IShip
    {
        private Titan() { }
        private static Titan _instance;

        public static Titan GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Titan();
            }
            return _instance;
        }

        public void Fly()
        {
            throw new NotImplementedException();
        }
    }
}
