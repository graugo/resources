using Ejercicio_SRP.Model;
using System.Xml.Linq;

namespace Ejercicio_SRP.Services
{
    internal class FightService
    {
        public FightService() { }
        public void Fight(Hero hero, Boss boss)
        {
            hero.Combat(boss);
            boss.Combat(hero);
            hero.Combat(boss);
            boss.Combat(hero);
            string heroName = hero.CharacterName();//String.IsNullOrEmpty(hero._name) ? "Hero" : hero._name;
            string bossName = boss.CharacterName();//String.IsNullOrEmpty(boss._name) ? "Boss" : boss._name;

            if (hero.Health <= 0) Console.WriteLine("{0} is dead!", heroName);
            else Console.WriteLine("{0} health {1}", heroName,  hero.Health);
            if (boss.Health <= 0) Console.WriteLine("{0} is dead!", bossName);
            else Console.WriteLine("{0} health {1}", bossName, boss.Health);
        }
    }
}
