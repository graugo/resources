using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behravior.ChainOfResponsability.Model
{
    internal class Worker
    {
        public string Name { get; }
        public bool Success { get; }
        public Worker(bool success, string name)
        {
            Success = success;
            Name = name;
        }
    }
}
