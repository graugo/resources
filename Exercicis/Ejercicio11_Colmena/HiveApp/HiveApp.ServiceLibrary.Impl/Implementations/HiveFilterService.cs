using HiveApp.Library.Model;
using HiveApp.ServiceLibrary.Contracts.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace HiveApp.ServiceLibrary.Impl
{
    public class HiveFilterService : IHiveFilterService
    {
        public List<BeeEntity> GetAllBees(HiveEntity hive)
        {
            return hive.BeeList;
        }

        public List<BeeEntity> GetBeesByincidents(HiveEntity hive, int incidents)
        {
            return (List<BeeEntity>) hive.BeeList.Where(x => x.Incidents >= incidents);
        }

        public List<BeeEntity> GetBeesByState(HiveEntity hive, bool state)
        {
            return (List<BeeEntity>) hive.BeeList.Where(x => x.State == state);
        }
    }
}
