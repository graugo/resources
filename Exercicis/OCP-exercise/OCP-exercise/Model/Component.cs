using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCP_exercise.Model
{
    internal class Component
    {
        public string? Name { get; private set; }
        public string? Description { get; private set;}
        public decimal BaseValue { get => baseValue; private set => baseValue = value; }
        private decimal baseValue;

        public Component(string name, string description, decimal value)
        {
            Name = name;
            Description = description;
            BaseValue = value;
        }
    }
}
