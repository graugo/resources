using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandlerApp.Model
{
    internal class Worker
    {
        public string Name { get; set; }
        public bool Success { get; set; }

        public Worker(string name, bool success)
        {
            Name = name;
            Success = success;
        }
    }
}
