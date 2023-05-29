using LifeApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeApp.Steps.Concrete
{
    internal class Adolescence : AbstractHandler
    {
        public override Person Handle(Person person)
        {
            Console.WriteLine($"{person.Name} is in their adolescence!");

            person.isHealthy = !(person.Life % 13 == 0);
            person.Life -= (person.isHealthy) ? 5 : 10;

            if (person.Life <= 0) return Person.Die(person);
            return (_next != null) ? _next.Handle(person) : person;
        }
    }
}
