using Ejercicio19_Subasta.Application.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ejercicio19_subasta.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BidController : ControllerBase
    {
        private readonly IBidService _bidService;

        public BidController(IBidService bidService)
        {
            _bidService = bidService;
        }

        /// <summary>
        /// Allows bidding in an auction
        /// </summary>
        /// <param name="id">Bid Id</param>
        /// <param name="value">Bid value</param>
        /// <returns></returns>
        [HttpPut]
        [Route("PutBid/{id}/{value}")]
        public IActionResult PutBid(int id, int value)
        {            
            return Ok(_bidService.BidOnAuction(id, value));
        }
    }
}
