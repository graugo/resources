using System;
using System.Collections.Generic;
using System.Linq;
using UnitTestApp.Infrastructure.Contracts;
using UnitTestApp.ServiceLibrary.Contracts;
using UnitTestApp.ServiceLibrary.Contracts.Models;

namespace UnitTestApp.ServiceLibrary.Impl
{
    public class OrderService : IOrderService
    {
        private IHeroRepository _heroRepository;

        public OrderService(IHeroRepository heroRepository)
        {
            _heroRepository = heroRepository;
        }

        public IEnumerable<Hero> Order(string orderFactor, string asc)
        {
            var orderedList = new List<Hero>();
            var heroList = _heroRepository.GetHeroes();
            if (heroList == null) 
            { 
                return orderedList; 
            }
            //orderFactor = string.IsNullOrEmpty(orderFactor) ? "nombre" : orderFactor;  
            if (asc?.ToLower() == "ascendente")
            {
                orderedList = heroList.OrderBy(x => typeof(Hero).GetProperties().FirstOrDefault(y => y.Name.ToLower() == (orderFactor?.ToLower() ?? "nombre"))?.GetValue(x)).ToList();
            }
            else
            {
                orderedList = heroList.OrderByDescending(x => typeof(Hero).GetProperties().FirstOrDefault(y => y.Name.ToLower() == (orderFactor?.ToLower() ?? "nombre"))?.GetValue(x)).ToList();
            }

            return orderedList;
        }
    }
}
