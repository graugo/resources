using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.EjercicioClase
{
    internal class Suma : CalculadoraAbst
    {
        public override decimal Calc()
        {
            return operator1 + operator2;
        }
    }
}
