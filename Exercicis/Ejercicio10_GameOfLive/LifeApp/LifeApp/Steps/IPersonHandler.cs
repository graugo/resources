using LifeApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeApp.Steps
{
    internal interface IPersonHandler
    {
        public Person Handle(Person person);
        public IPersonHandler SetNext(IPersonHandler next);
    }
}
