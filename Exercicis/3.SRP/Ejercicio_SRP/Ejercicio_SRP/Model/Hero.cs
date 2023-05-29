using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_SRP.Model
{
    internal class Hero : Character
    {
 
        private int _healthPotion = 0;
        private int _defenseScroll = 0;
        private int _damageScroll = 0;
        private bool _buyScrolls;

        public Hero()
        {
            Name = "Hero";
            _damage = 10;
            _defense = 3;
            _health = 20;
        }

        public Hero(int damage, int defense, int health, bool buyScrolls, string name)
        {
            _damage = damage;
            _defense = defense;
            _health = health;
            Name = name;
            _buyScrolls = buyScrolls;
        }

        public override string CharacterName()
        {
            return String.IsNullOrEmpty(Name) ? "Hero" : Name;
        }

        void Buy()
        {
            _defenseScroll++;
            _damageScroll++;
            _healthPotion++;
        }

        void PowerUp()
        {
            _defense = _defense + 30;
            _damage = _damage + 50;
            _defenseScroll--;
            _damageScroll--;
        }
        void HealPotion()
        {
            _health = _health + 25;
            _healthPotion--;
        }
        public override void Combat(Character boss)
        {
            //buy fase
            if (_buyScrolls)
            {
                Buy();
            }
            //hero power up
            if (boss.Health > 50 && (_defenseScroll > 0 && _damageScroll > 0))
            {
                PowerUp();
            }
            //hero attack
            Attack(boss);
            //hero defense
            if (_health < 10)
            {
                Heal();
            }
            //hero healing
            if (_health < 5 && _healthPotion != 0)
            {
                HealPotion();
            }
        }
    }

}
