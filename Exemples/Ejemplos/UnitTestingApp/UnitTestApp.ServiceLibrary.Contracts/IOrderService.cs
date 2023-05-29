using System.Collections.Generic;
using UnitTestApp.ServiceLibrary.Contracts.Models;

namespace UnitTestApp.ServiceLibrary.Contracts
{
    public interface IOrderService
    {
        IEnumerable<Hero> Order(string orderFactor, string asc);
    }
}
