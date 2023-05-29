using HiveApp.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiveApp.ServiceLibrary.Contracts.Contracts
{
    public interface IBeeService
    {
        List<BeeEntity> GetBeeList();
        List<BeeEntity> GetBeesFilter(decimal polen, int incidents, bool state);
        int PostBee(BeeEntity bee);
        int PutBee(int id, BeeEntity bee);
        int DeleteBee(int id);
    }
}
