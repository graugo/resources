using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeApp.Model
{
    internal class Person
    {
        public string? Name { get; private set; }
        public int Life { get; set; }
        public bool isDead { get; private set; }
        public bool isHealthy { get; set; }

        public Person(string name, int life)
        {
            Name = name;
            Life = life;
        }

        public static Person Die(Person p)
        {
            p.isDead = true;
            Console.WriteLine($"{p.Name} died!");
            return p;
        }
    }
}
