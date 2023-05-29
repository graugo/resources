using LifeApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeApp.Steps.Concrete
{
    internal class OldAge : AbstractHandler
    {
        public override Person Handle(Person person)
        {
            Console.WriteLine($"{person.Name} is of old age!");

            person.isHealthy = !(person.Life % 2 == 0);
            person.Life -= (person.isHealthy) ? 10 : 30;

            if (person.Life <= 0) return Person.Die(person);
            return (_next != null) ? _next.Handle(person) : person;
        }
    }
}
