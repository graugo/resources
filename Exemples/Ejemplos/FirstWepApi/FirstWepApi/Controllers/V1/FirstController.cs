using Microsoft.Web.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FirstWepApi.Controllers.V1
{
    /// <summary>
    /// First Controller
    /// </summary>
    [ApiVersion("1")]
    [RoutePrefix("api/v{version:ApiVersion}/First")]
    public class FirstController : ApiController
    {
        /// <summary>
        /// Return a string
        /// </summary>
        /// <returns>an string said hello world</returns>
        [HttpGet]
        [Route("")]
        public IHttpActionResult Get() 
        {
            return Ok("Hello World!");
        }
    }
}
