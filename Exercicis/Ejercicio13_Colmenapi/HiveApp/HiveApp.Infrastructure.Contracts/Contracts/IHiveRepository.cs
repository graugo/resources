using HiveApp.Infrastructure.Contracts.Models;
using HiveApp.Library.Model;
using System.Collections.Generic;

namespace HiveApp.Infrastructure.Contracts.Contracts
{
    public interface IHiveRepository
    {
        HiveEntity ReadHive();
        void WriteHive(HiveDTO hive);
    }
}
