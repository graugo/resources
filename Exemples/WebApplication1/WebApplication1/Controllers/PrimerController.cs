using Microsoft.Web.Http;

using System.Web.Http;

namespace WebApplication1.Controllers
{
    /// <summary>
    /// Primer Controller
    /// </summary>
    [ApiVersion("1")]
    [RoutePrefix("api/v(version:ApiVersion)/First")]
    public class PrimerController : ApiController
    {
        /// <summary>
        /// Get()
        ///     Basic method
        /// </summary>
        /// <returns>
        /// Returns string "Hello World"
        /// </returns>
        [HttpGet]
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok("Hello World");
        }
        /// <summary>
        /// Get(name)
        ///     Basic Method
        /// </summary>
        /// <param name="name">Name of the user</param>
        /// <returns>Returns string with user input</returns>
        [HttpGet]
        [Route("GetName/(name?)")]
        public IHttpActionResult Get(string name = null)
        {
            return Ok($"Hello {name}");
        }
    }
}
