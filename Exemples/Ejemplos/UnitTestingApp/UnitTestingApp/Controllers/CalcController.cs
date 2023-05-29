using System.Web.Http;
using UnitTestApp.ServiceLibrary.Contracts;
using UnitTestApp.ServiceLibrary.Impl;
using UnitTestApp.Infrastructure.Impl;

namespace UnitTestingApp.Controllers
{
    [RoutePrefix("api/Calculate")]
    public class CalcController : ApiController
    {
        private readonly ICalcService _calcService;
        public CalcController()
        {
            _calcService = new CalcService(new CalcRepository());
        }

        [HttpGet()]
        [Route("Calc/{x}/{y}")]
        public IHttpActionResult Calc(int x, int y) 
        {
            return Ok(_calcService.Calc(x, y));
        }

        [HttpGet()]
        [Route("calcDecimal/{x}")]
        public IHttpActionResult CalcDecimal(decimal x) 
        {
            return Ok(_calcService.Calc(x));
        }
    }
}
