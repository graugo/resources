using LifeApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeApp.Steps.Concrete
{
    internal class Adulthood : AbstractHandler
    {
        public override Person Handle(Person person)
        {
            Console.WriteLine($"{person.Name} is in their adulthood!");
            
            person.isHealthy = !(person.Life > 50);
            person.Life -= (person.isHealthy) ? 10 : 20;

            if (person.Life <= 0) return Person.Die(person);
            return (_next != null) ? _next.Handle(person) : person;
        }
    }
}
