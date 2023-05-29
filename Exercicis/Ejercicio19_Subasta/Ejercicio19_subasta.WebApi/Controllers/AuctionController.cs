using AutoMapper;
using Ejercicio19_subasta.WebApi.Models;
using Ejercicio19_Subasta.Application.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Ejercicio19_subasta.WebApi.Controllers
{
    /// <summary>
    /// Auction Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuctionController : ControllerBase
    {
        private readonly IAuctionService _service;
        private readonly IBidService _bidService;
        private readonly IMapper _mapper;
        public AuctionController(IAuctionService service, IBidService bidService, IMapper mapper)
        {
            _service = service;
            _bidService = bidService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get Active Auctions
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetActiveAuctions")]
        public async Task<IActionResult> GetActiveAuctions()
        {
            var auctions = _bidService.GetAliveAuctions();
            if (auctions == null)
            {
                return NotFound();
            }
            var result = _mapper.Map<List<PokemonResponse>>(auctions);
            return Ok(result);
        }

        /// <summary>
        /// Get Auction by Id
        /// </summary>
        /// <param name="id">Auction Id</param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAuctionById/{id}")]
        public async Task<IActionResult> GetAuctionById(int id)
        {
            var auctions = _bidService.GetAuctionById(id);
            return Ok(auctions);
        }

        /// <summary>
        /// Register Auction
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> RegisterAuction()
        {
            return Ok(await _service.Register());
        }
    }
}
