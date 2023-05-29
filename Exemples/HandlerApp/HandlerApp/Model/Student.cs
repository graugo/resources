using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandlerApp.Model
{
    internal class Student
    {
        public string Name { get; set; }
        public int Knowledge { get; set; }

        public Student(string name, int knowledge)
        {
            this.Name = name;
            this.Knowledge = knowledge;
        }

    }
}
