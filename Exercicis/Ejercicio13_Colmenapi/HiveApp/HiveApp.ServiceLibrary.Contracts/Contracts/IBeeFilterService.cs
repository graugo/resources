using HiveApp.Library.Model;
using System.Collections.Generic;

namespace HiveApp.ServiceLibrary.Contracts.Contracts
{
    public interface IBeeFilterService
    {
        List<BeeEntity> GetAllBees();
        List<BeeEntity> GetBeesByState( bool state);
        List<BeeEntity> GetBeesByIncidents(int incidents);
        List<BeeEntity> GetBeesByPollen(double pollen);
    }
}
