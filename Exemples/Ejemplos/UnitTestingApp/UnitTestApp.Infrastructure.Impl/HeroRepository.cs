using System.Collections.Generic;
using UnitTestApp.Infrastructure.Contracts;
using UnitTestApp.ServiceLibrary.Contracts.Models;

namespace UnitTestApp.Infrastructure.Impl
{
    public class HeroRepository : IHeroRepository
    {
        private static List<Hero> _heroes;

        public HeroRepository()
        {
            InitializeCollection();
        }

        private void InitializeCollection()
        {
            if (_heroes == null)
            {
                _heroes = new List<Hero>();
            }     
        }

        public bool DeleteHero()
        {
            if (_heroes != null)
            {
                _heroes.Clear();
                return true;
            }
            return false;
        }

        public IEnumerable<Hero> GetHeroes()
        {
            return _heroes;
        }

        public bool SaveHero(Hero hero)
        {
            if (hero != null)
            {
                _heroes.Add(hero);
                return true;
            }
            return false;
        }
    }
}
