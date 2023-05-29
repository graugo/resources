using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.EjercicioClase
{
    internal abstract class CalculadoraAbst
    {
        public decimal operator1 { get; set; }
        public decimal operator2 { get; set; }

        public abstract decimal Calc();
    }
}
