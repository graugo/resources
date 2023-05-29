using HandlerApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandlerApp.Handlers
{
    internal class Week1 : StudentHandler
    {
        public override Worker Handle(Student student)
        {
            if (student.Name.Contains("a")) student.Knowledge++;
            else student.Knowledge--;
            if (student.Knowledge == 0) return new Worker(student.Name, false);
            if (this.next != null) return next.Handle(student);
            return new Worker(student.Name, true);
        }
    }
}
