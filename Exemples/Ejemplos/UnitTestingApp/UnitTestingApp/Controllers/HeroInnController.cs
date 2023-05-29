using System.Web.Http;
using UnitTestApp.Infrastructure.Contracts;
using UnitTestApp.Infrastructure.Impl;
using UnitTestApp.ServiceLibrary.Contracts;
using UnitTestApp.ServiceLibrary.Contracts.Models;
using UnitTestApp.ServiceLibrary.Impl;

namespace UnitTestingApp.Controllers
{
    [RoutePrefix("api/HeroInn")]
    public class HeroInnController : ApiController
    {
        private readonly ISaveService _saveService;
        private readonly IOrderService _orderService;
        private readonly IPersistService _persistService;

        public HeroInnController(ISaveService saveService, IOrderService orderService, IPersistService persistService)
        {
            _saveService = saveService;
            _orderService = orderService;
            _persistService = persistService;
        }

        [HttpPost]
        [Route("AddHero")]
        public IHttpActionResult AddHero(Hero hero) 
        {
            return Ok(_saveService.Save(hero));
        }

        [HttpGet]
        [Route("OrderBy/{orderFactor}/{asc}")]
        public IHttpActionResult OrderBy(string orderFactor, string asc) 
        {
            return Ok(_orderService.Order(orderFactor, asc));
        }

        [HttpPost]
        [Route("Persist")]
        public IHttpActionResult Persist() 
        {
            return Ok(_persistService.Persist());
        }
    }
}
