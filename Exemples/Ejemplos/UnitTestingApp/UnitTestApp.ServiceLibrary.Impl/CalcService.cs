using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestApp.Infrastructure.Contracts;
using UnitTestApp.ServiceLibrary.Contracts;

namespace UnitTestApp.ServiceLibrary.Impl
{
    public class CalcService : ICalcService
    {
        private ICalcRepository _calcRepository;

        public CalcService(ICalcRepository calcRepository)
        {
            _calcRepository = calcRepository;
        }

        public int Calc(int x, int y)
        {
            return x + y;
        }

        public decimal Calc(decimal x) 
        {
            return x * _calcRepository.GetDecimal();
        }
    }
}
