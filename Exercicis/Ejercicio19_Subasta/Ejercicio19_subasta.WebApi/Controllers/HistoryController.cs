using Ejercicio19_Subasta.Application.Contracts;
using Ejercicio19_Subasta.Application.Implementation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ejercicio19_subasta.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryController : ControllerBase
    {
        private readonly IHistoryService _historicService;

        public HistoryController(IHistoryService historicService)
        {
            _historicService = historicService;
        }
        /// <summary>
        /// Get auction history
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetHistory")]
        public IActionResult GetHistory()
        {
            return Ok(_historicService.GetHistory());
        }
    }
}
