using HandlerApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandlerApp.Handlers
{
    internal class StudentHandler : IHandler
    {
        protected IHandler? next;
        public virtual Worker Handle(Student student) { return null; }
        public IHandler SetNext(IHandler handler)
        {
            next = handler;
            return handler;
        }
    }
}
