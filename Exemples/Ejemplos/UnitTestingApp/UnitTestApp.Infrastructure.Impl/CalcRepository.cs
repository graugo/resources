using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestApp.Infrastructure.Contracts;

namespace UnitTestApp.Infrastructure.Impl
{
    public class CalcRepository : ICalcRepository
    {
        public decimal GetDecimal()
        {
            return 1.2M;
        }
    }
}
