using System.Collections.Generic;
using UnitTestApp.ServiceLibrary.Contracts.Models;

namespace UnitTestApp.Infrastructure.Contracts
{
    public interface IHeroRepository
    {
        IEnumerable<Hero> GetHeroes();
        bool SaveHero(Hero hero);
        bool DeleteHero();
    }
}
