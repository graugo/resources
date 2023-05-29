using LifeApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeApp.Steps
{
    internal abstract class AbstractHandler : IPersonHandler
    {
        protected IPersonHandler? _next;

        public abstract Person Handle(Person person);

        public IPersonHandler SetNext(IPersonHandler next)
        {
            this._next = next;
            // Allows for linked call
            // birth.SetNext(childhood).SetNext(adolescence).SetNext(adulthood);
            return next;
        }
    }
}
