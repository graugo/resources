using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_SRP.Model
{
    internal abstract class Character
    {
        public int Health { get => _health; set { _health = value; } }

        protected int _damage;
        protected int _defense;
        protected int _health;
        public string? Name { get; protected set; }

        protected void Attack(Character enemy)
        {
            enemy.Health -= _damage;
        }
        protected void Heal()
        {
            _health = _health + _defense;
        }
        public abstract void Combat(Character c);
        public abstract string CharacterName();
    }
}
