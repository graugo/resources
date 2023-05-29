using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_SRP.Model
{
    internal class Boss : Character
    {
        public Boss() 
        {
            _damage = 20;
            _defense = 3;
            _health = 50;
            Name = "Boss";
        }

        public Boss(int damage, int defense, int health, string name)
        {
            _damage = damage;
            _defense = defense;
            _health = health;
            Name = name;
        }
        public override string CharacterName()
        {
            return String.IsNullOrEmpty(Name) ? "Boss" : Name;
        }

        public override void Combat(Character hero)
        {
            //Boss defense
            Heal();
            //Boss damage
            Attack(hero);
        }
    }
}
