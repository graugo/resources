using EJ15.Tournament.ServiceLibrary.Contracts.Contract;
using System.Threading.Tasks;
using System.Web.Http;

namespace EJ15.Tournament.WebApi.Controllers
{
    /// <summary>
    /// Controller to manage Trainers
    /// </summary>
    [RoutePrefix("api/Trainer")]
    public class TrainerController : ApiController
    {
        private readonly ITrainerService _trainerService;

        public TrainerController(ITrainerService trainerService)
        {
            _trainerService = trainerService;
        }

        /// <summary>
        /// Create a random trainer
        /// </summary>
        /// <returns>Trainer Id in GUID format</returns>
        [HttpPost]
        [Route("CreateTrainer")]
        public async Task<IHttpActionResult> CreateTrainer() 
        {
            return Ok(await _trainerService.CreateTrainer());
        }
    }
}
