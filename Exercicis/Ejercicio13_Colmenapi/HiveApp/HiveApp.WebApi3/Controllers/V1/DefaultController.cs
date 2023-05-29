using Microsoft.Web.Http;
using System.Web.Http;

namespace HiveApp.WebApi3.Controllers.V1
{
    [ApiVersion("1")]
    [RoutePrefix("api/v{version:ApiVersion}/Default")]
    public class DefaultController : ApiController
    {
        [HttpGet]
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok("helloooo");
        }
        [HttpGet]
        [Route("second")]
        public IHttpActionResult Get()
        {
            return Ok();
        }

    }
}
