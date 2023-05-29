using DesignPatterns.Behravior.ChainOfResponsability.Model;

namespace DesignPatterns.Behravior.ChainOfResponsability.Steps
{
    internal class Week1 : StudentHandler
    {
        public override Worker HandlerStudent(Student student)
        {
            if (student.Name.Contains("a")) 
                student.Knowledge++; 
            else student.Knowledge--; 
            if (student.Knowledge == 0) 
                return new Worker(name:student.Name, success:false); 
            if (successor is not null) 
                return successor.HandlerStudent(student); 
            return new Worker(name:student.Name, success:true);
        }
    }
}
