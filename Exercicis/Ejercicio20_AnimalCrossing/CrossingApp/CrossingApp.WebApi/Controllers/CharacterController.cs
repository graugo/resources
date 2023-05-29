using CrossingApp.Application.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CrossingApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _service;
        public CharacterController(ICharacterService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("GetCharacter/{id}")]
        public async Task<ActionResult> GetCharacter(int id)
        {
            return Ok(await _service.GetCharacter(id));
        }
    }
}
