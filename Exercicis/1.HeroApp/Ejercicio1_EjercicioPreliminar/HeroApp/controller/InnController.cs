using HeroApp.classes;

namespace HeroApp.controller
{
    public class InnController
    {        
        public static Hero CreateHero(string name)
        {
            Hero hero = new Hero();
            hero.SetName(name);
            return hero;
        }

        public static string ListHeroes(Inn inn)
        {
            // TODO
            string s = "";
            foreach (Hero hero in inn.GetHeroList())
            {
                s += "\n" + hero.GetName();
            }
            return s;
        }
    }   
}

