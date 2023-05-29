using DesignPatterns.Behravior.ChainOfResponsability.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behravior.ChainOfResponsability
{
    internal abstract class StudentHandler
    {
        protected StudentHandler successor;
        public abstract Worker HandlerStudent(Student student);

        public void SetNext(StudentHandler successor) 
        { 
            this.successor = successor; 
        }
    }
}
