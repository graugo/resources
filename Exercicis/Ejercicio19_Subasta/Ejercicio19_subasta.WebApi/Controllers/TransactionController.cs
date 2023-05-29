using Ejercicio19_Subasta.Application.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ejercicio19_subasta.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _service;

        public TransactionController(ITransactionService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("GetTransactions/{auctionId}")]
        public IActionResult GetTransactionsByAuctionId(int auctionId)
        {
            var result = _service.GetTransactionsByAuctionId(auctionId);
            if (result == null) { return  NotFound("Not transactions found for the given auction id."); }
            return Ok(result);
        }
    }
}
