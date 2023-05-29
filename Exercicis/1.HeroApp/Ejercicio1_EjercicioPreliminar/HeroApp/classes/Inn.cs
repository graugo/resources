namespace HeroApp.classes
{
    public class Inn
    {
        private List<Hero> heroList;
        
        public Inn()
        {
            heroList = new List<Hero>();
        }

        public void AddHero(Hero hero)
        {
            heroList.Add(hero);
        }

        public void RemoveHero(string heroName)
        {
            // TODO remove hero
        }

        public List<Hero> GetHeroList() 
        { 
            return heroList; 
        }
    }
}
