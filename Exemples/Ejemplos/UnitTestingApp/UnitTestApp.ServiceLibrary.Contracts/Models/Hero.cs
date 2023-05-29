using System.Collections.Generic;
using System.Linq;

namespace UnitTestApp.ServiceLibrary.Contracts.Models
{
    public class Hero
    {
        public string Nombre { get; set; }
        public int Nivel { get; set; }
        public bool EstaContratado { get; set; }
        public IEnumerable<Hability> ListaHabilidades { get; set; }

        public override string ToString()
        {
            return $"{Nombre} {Nivel} {EstaContratado} {ListaHabilidades?.Count()}";
        }
    }
}
