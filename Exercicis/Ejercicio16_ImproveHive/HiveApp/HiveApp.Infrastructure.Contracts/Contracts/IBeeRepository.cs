using HiveApp.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiveApp.Infrastructure.Contracts.Contracts
{
    public interface IBeeRepository
    {
        List<BeeEntity> GetBees();
        List<BeeEntity> GetBeesByFilter(decimal polen, int incidents, bool state);
        int PostBee(BeeEntity bee);
        int PutBee(int id, BeeEntity bee);
        int DeleteBee(int id);
    }
}
