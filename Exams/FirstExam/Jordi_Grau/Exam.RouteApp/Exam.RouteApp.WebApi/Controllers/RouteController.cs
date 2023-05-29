using Exam.RouteApp.ServiceLibrary.Contracts.Contracts;
using Exam.RouteApp.WebApi.Mappers;
using System.Threading.Tasks;
using System.Web.Http;

namespace Exam.RouteApp.WebApi.Controllers
{
    /// <summary>
    /// Controller for all endpoints related with travel and cost simulation
    /// </summary>
    [RoutePrefix("Route")]
    public class RouteController : ApiController
    {
        private readonly IRouteService _routeService;
        private readonly IMapper _mapper;

        public RouteController(IRouteService routeService, IMapper mapper)
        {
            _mapper = mapper;
            _routeService = routeService;
        }

        /// <summary>
        /// Returns all planets and their codes
        /// </summary>
        /// <returns>List of planets</returns>
        [HttpGet]
        [Route("GetPlanets")]
        public async Task<IHttpActionResult> GetPlanets() 
        {
            var planets = await _routeService.GetPlanetsAsync();
            return Ok(_mapper.ToPlanetResponseList(planets));
        }

        /// <summary>
        /// Returns all possible Routes
        /// </summary>
        /// <returns> Returns all possible Routes</returns>
        [HttpGet]
        [Route("GetRoutes")]
        public async Task<IHttpActionResult> GetRoutes()
        {
            var routes = await _routeService.GetRoutesAsync();
            return Ok(_mapper.ToRouteResponseList(routes));
        }

        /// <summary>
        /// Returns a single routes price depending on base prices and taxes
        /// </summary>
        /// <param name="origin">origin planet code</param>
        /// <param name="destination">destination planet code</param>
        /// <returns>Returns a single routes price</returns>
        [HttpGet]
        [Route("GetPrice")]
        public async Task<IHttpActionResult> GetPrice(string origin, string destination)
        {
            var price = await _routeService.GetRoutePriceAsync(origin, destination);
            return Ok(_mapper.ToPriceResponse(price));
        }
    }
}
