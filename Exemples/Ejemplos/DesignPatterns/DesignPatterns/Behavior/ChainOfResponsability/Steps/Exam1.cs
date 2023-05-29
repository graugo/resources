using DesignPatterns.Behravior.ChainOfResponsability.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behravior.ChainOfResponsability.Steps
{
    internal class Exam1 : StudentHandler
    {
        public override Worker HandlerStudent(Student student)
        {
            if (student.Knowledge >= 4)
            {
                student.Knowledge++;
            }
            else if (student.Knowledge >= 10)
            {
                return new Worker(true, student.Name);
            }
            else
            {
                student.Knowledge--;
            }
            if (successor is not null)
            {
                return successor.HandlerStudent(student);
            }
            return new Worker(false, student.Name);
        }
    }
}
