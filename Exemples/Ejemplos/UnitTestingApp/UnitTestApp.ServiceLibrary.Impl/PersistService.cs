using System.Collections.Generic;
using System.IO;
using UnitTestApp.Infrastructure.Contracts;
using UnitTestApp.ServiceLibrary.Contracts;

namespace UnitTestApp.ServiceLibrary.Impl
{
    public class PersistService : IPersistService
    {
        private IHeroRepository _heroRepository;
        private IHeroFileRepository _heroFileRepository;

        public PersistService(IHeroRepository heroRepository, IHeroFileRepository heroFileRepository)
        {
            _heroRepository = heroRepository;
            _heroFileRepository = heroFileRepository;
        }

        public bool Persist()
        {
            var heroes = _heroRepository.GetHeroes();
            var heroToString = new List<string>();
            foreach (var x in heroes)
            {
                heroToString.Add(x.ToString());
            }
            if (heroToString.Count > 0) 
                return _heroFileRepository.Save(heroToString)&&
                       _heroRepository.DeleteHero();
            else
                return false;
        }
        //OK
        //null list
        //KO
    }
}
