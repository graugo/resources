using HiveApp.Infrastructure.Contracts.Contracts;
using HiveApp.Library.Model;
using HiveApp.ServiceLibrary.Contracts.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace HiveApp.ServiceLibrary.Impl
{
    public class BeeFilterService : IBeeFilterService
    {
        private IHiveRepository _hiveRepository;

        public BeeFilterService(IHiveRepository hiveRepository)
        {
            _hiveRepository = hiveRepository;
        }
        public List<BeeEntity> GetAllBees()
        {
            var hive = _hiveRepository.ReadHive();
            var bees = hive.BeeList;
            return bees;
        }

        public List<BeeEntity> GetBeesByIncidents(int incidents)
        {
            var hive = _hiveRepository.ReadHive();
            return (List<BeeEntity>)hive.BeeList.Where(x => x.Incidents >= incidents);
        }

        public List<BeeEntity> GetBeesByState( bool state)
        {
            var hive = _hiveRepository.ReadHive();
            return (List<BeeEntity>) hive.BeeList.Where(x => x.State == state);
        }
        
        public List<BeeEntity> GetBeesByPollen(double pollen)
        {
            var hive = _hiveRepository.ReadHive();
            throw new System.NotImplementedException();
        }
    }
}
