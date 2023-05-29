using Autofac.Core;
using FirstWepApi.Models;
using FirstWepApi.Services;
using Microsoft.Web.Http;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Web.Http;

namespace FirstWepApi.Controllers.V2
{
    /// <summary>
    /// Second Controller
    /// </summary>
    [ApiVersion("2")]
    [RoutePrefix("api/v{version:ApiVersion}/First")]
    public class SecondController : ApiController
    {
        private readonly IFooService _fooService;

        public SecondController(IFooService fooService)
        {
            _fooService = fooService;
        }


        /// <summary>
        /// Returns an string with values
        /// </summary>
        /// <param name="age">your age</param>
        /// <param name="name">your name</param>
        /// <returns>an string with your name and your age</returns>
        [HttpGet]
        [Route("GetName/{age}")]
        [SwaggerResponse(HttpStatusCode.OK, "string", typeof(string))]
        [SwaggerResponse(HttpStatusCode.BadRequest, "string", typeof(string))]
        public IHttpActionResult Get(int age,[FromUri]string name = null) 
        {
            return Ok($"Hello {name} {age}");
        }

        /// <summary>
        /// Obsolete endpoint
        /// </summary>
        /// <returns>void</returns>
        [Obsolete]
        [HttpGet]
        [Route("")]
        public IHttpActionResult Get() 
        {
            return Ok();
        }

        [HttpPost]
        [Route("Create")]
        public IHttpActionResult CreateData(string str) 
        {
            return Ok(_fooService.Get(str));
        }

        [HttpPut]
        [Route("Update")]
        public IHttpActionResult UpdateData() 
        {
            return Ok();
        }

        [HttpDelete]
        [Route("Delete")]
        public IHttpActionResult DeleteData() 
        {
            return Ok();
        }

        [HttpPatch]
        [Route("ParcialUpdate")]
        public IHttpActionResult UpdateParcialData() 
        {
            return Ok();
        }
    }
}
