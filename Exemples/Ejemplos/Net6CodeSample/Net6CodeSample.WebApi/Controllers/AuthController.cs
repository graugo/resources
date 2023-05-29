using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Net6CodeSample.WebApi.Autentication;

namespace Net6CodeSample.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAutenticationService _autenticateService;
        public AuthController(IAutenticationService autenticateService)
        {
            _autenticateService = autenticateService;
        }

        [HttpGet]
        [Route("token/{profile}")]
        public IActionResult GetToken(string profile) 
        {
            var user = _autenticateService.Autenticate(profile);
            if (!string.IsNullOrEmpty(user)) 
            {
                var token = _autenticateService.Generate(user);
                return Ok(token);
            }
            return NotFound("Not user Found");
        }
    }
}
