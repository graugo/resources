using EX.First.ServiceLibrary.Contracts.Contracts;
using EX.First.WebApi.Mapper;
using EX.First.WebApi.Models.Request;
using System.Threading.Tasks;
using System.Web.Http;

namespace EX.First.WebApi.Controllers
{
    /// <summary>
    /// Route Controller
    /// </summary>
    [RoutePrefix("api/Route")]
    public class RouteController : ApiController
    {
        private readonly IRouteService _routeService;
        private readonly IRouteMapper _mapper;

        public RouteController(IRouteService routeService, IRouteMapper mapper)
        {
            _routeService = routeService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all routes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetRoutes")]
        public async Task<IHttpActionResult> GetRoutes() 
        {
            var routes = await _routeService.GetRoutes();
            if (routes == null) return NotFound();
            var result = _mapper.ToRouteResponseList(routes);
            
            return Ok(result);
        }

        /// <summary>
        /// Get cost from specific route
        /// </summary>
        /// <param name="route">contains origin and destination route</param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetRouteCost")]
        public async Task<IHttpActionResult> GetRouteCost([FromUri]RouteRequest route) 
        {
            if (route == null) return BadRequest();
            if (string.IsNullOrEmpty(route.Origin)) return BadRequest("Origin not valid");
            if (string.IsNullOrEmpty(route.Destination)) return BadRequest();
            var routeCost = await _routeService.GetRouteCost(route.Origin, route.Destination);
            if (routeCost == null) return NotFound();
            var result = _mapper.ToRouteCostResponse(routeCost);
            
            return Ok(result);
        }
    }
}
