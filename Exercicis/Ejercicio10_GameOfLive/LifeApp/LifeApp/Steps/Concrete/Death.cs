using LifeApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeApp.Steps.Concrete
{
    internal class Death : AbstractHandler
    {
        public override Person Handle(Person person)
        {
            Console.WriteLine($"{person.Name} lived for {person.Life} more year(s)!");
            return Person.Die(person);
        }
    }
}
