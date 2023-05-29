using DesignPatterns.Behravior.ChainOfResponsability.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behravior.ChainOfResponsability.Steps
{
    internal class Week3 : StudentHandler
    {
        public override Worker HandlerStudent(Student student)
        {
            if (student.Name.Contains("r"))
                student.Knowledge++;
            else student.Knowledge--;
            if (student.Knowledge == 0)
                return new Worker(name: student.Name, success: false);
            if (successor is not null)
                return successor.HandlerStudent(student);
            return new Worker(name: student.Name, success: true);
        }
    }
}
