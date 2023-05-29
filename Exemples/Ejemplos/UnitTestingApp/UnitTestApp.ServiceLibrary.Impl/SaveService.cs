using UnitTestApp.Infrastructure.Contracts;
using UnitTestApp.ServiceLibrary.Contracts;
using UnitTestApp.ServiceLibrary.Contracts.Models;

namespace UnitTestApp.ServiceLibrary.Impl
{
    public class SaveService : ISaveService
    {
        private IHeroRepository _heroRepository;

        public SaveService(IHeroRepository heroRepository)
        {
            _heroRepository = heroRepository;
        }

        public bool Save(Hero hero)
        {
            if (hero != null) 
            {
                return _heroRepository.SaveHero(hero);
            }
            return false;
        }
    }
}
