using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestApp.ServiceLibrary.Contracts
{
    public interface ICalcService
    {
        int Calc(int x, int y);

        decimal Calc(decimal x);
    }
}
