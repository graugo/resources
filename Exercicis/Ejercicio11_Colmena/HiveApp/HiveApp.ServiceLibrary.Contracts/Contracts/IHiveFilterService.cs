using HiveApp.Library.Model;
using System.Collections.Generic;

namespace HiveApp.ServiceLibrary.Contracts.Contracts
{
    public interface IHiveFilterService
    {
        List<BeeEntity> GetAllBees(HiveEntity hive);
        List<BeeEntity> GetBeesByState(HiveEntity hive, bool state);
        List<BeeEntity> GetBeesByincidents(HiveEntity hive, int incidents);
    }
}
