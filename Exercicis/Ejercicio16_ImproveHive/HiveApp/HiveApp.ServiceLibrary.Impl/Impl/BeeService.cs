using HiveApp.Infrastructure.Contracts.Contracts;
using HiveApp.Library.Models;
using HiveApp.ServiceLibrary.Contracts.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiveApp.ServiceLibrary.Impl.Impl
{
    public class BeeService : IBeeService
    {
        private readonly IBeeRepository _beeRepository;
        
        public BeeService(IBeeRepository beeRepository)
        {
            _beeRepository = beeRepository;
        }

        public int DeleteBee(int id)
        {
            throw new NotImplementedException();
        }

        public List<BeeEntity> GetBeeList()
        {
            return _beeRepository.GetBees();
        }

        public List<BeeEntity> GetBeesFilter(int incidents, bool state)
        {
            throw new NotImplementedException();
        }

        public List<BeeEntity> GetBeesFilter(decimal polen, int incidents, bool state)
        {
            throw new NotImplementedException();
        }

        public int PostBee(BeeEntity bee)
        {
            return _beeRepository.PostBee(bee);
        }

        public int PutBee(int id, BeeEntity bee)
        {
            throw new NotImplementedException();
        }
    }
}
