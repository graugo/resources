using HiveApp.ServiceLibrary.Contracts.Contracts;
using Microsoft.Web.Http;
using Newtonsoft.Json;
using System.Web.Http;

namespace HiveApp.WebApi.Controllers.V1
{
    /// <summary>
    /// Controller for filtering bee data
    /// </summary>
    [ApiVersion("1")]
    [RoutePrefix("api/v{version:ApiVersion}/getBees")]
    public class FilterController : ApiController
    {
        private readonly IBeeFilterService _beeFilterService;

        public FilterController (IBeeFilterService beeFilterService)
        {
            _beeFilterService = beeFilterService;
        }
        /// <summary>
        /// Get all bees
        /// </summary>
        /// <returns>A list of all bees</returns>
        [HttpGet]
        [Route("all")]
        public IHttpActionResult GetAllBees()
        {
            string response = string.Empty;
            var bees = _beeFilterService.GetAllBees();
            response = JsonConvert.SerializeObject(bees);
            return Ok(bees);
        }
        /// <summary>
        /// Get bees filtered by State
        /// </summary>
        /// <param name="state"></param>
        /// <returns>Bees with state matching query</returns>
        [HttpGet]
        [Route("state/{state}")]
        public IHttpActionResult GetBeesByState(bool state)
        {
            string response = string.Empty;
            response = JsonConvert.SerializeObject(_beeFilterService.GetBeesByState(state));
            return Ok(response);
        }
        /// <summary>
        /// Get Bees filtered by number of incidents
        /// </summary>
        /// <param name="incidents"></param>
        /// <returns>Returns bees with number of incidents equal or avobe specified</returns>
        [HttpGet]
        [Route("incidents/{incidents}")]
        public IHttpActionResult GetBeesByIncidents(int incidents)
        {
            string response = string.Empty;
            response = JsonConvert.SerializeObject(_beeFilterService.GetBeesByIncidents(incidents));
            return Ok(response);
        }
        /// <summary>
        /// Get Bees filtered by amount of pollen recollected
        /// </summary>
        /// <param name="pollen"></param>
        /// <returns>Returns bees with grams of pollen equal or avobe specified</returns>
        [HttpGet]
        [Route("pollen/{pollen}")]
        public IHttpActionResult GetBeesByPollen(double pollen)
        {
            string response = string.Empty;
            response = JsonConvert.SerializeObject(_beeFilterService.GetBeesByPollen(pollen * 1000));
            return Ok(response);
        }
    }
}
