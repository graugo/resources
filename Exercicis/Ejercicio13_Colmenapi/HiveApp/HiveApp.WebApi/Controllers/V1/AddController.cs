using HiveApp.Library.Model;
using HiveApp.ServiceLibrary.Contracts.Contracts;
using Microsoft.Web.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HiveApp.WebApi.Controllers.V1
{
    /// <summary>
    /// Controller for actions regarding bee upload
    /// </summary>
    [ApiVersion("1")]
    [RoutePrefix("api/v{version:ApiVersion}/add")]
    public class AddController : ApiController
    {
        private readonly IBeeCreateService _beeCreateService;

        public AddController(IBeeCreateService beeCreateService)
        {
            _beeCreateService = beeCreateService;
        }

        [HttpPut]
        [Route("")]
        public IHttpActionResult Put(int id, string name, decimal recollection, long time, bool state, int incidents)
        {
            _beeCreateService.Create(
                new BeeEntity
                {
                    Id = id,
                    Name = name,
                    Recollection = recollection,
                    Time = time,
                    State = state,
                    Incidents = incidents
                }
            );
            return Ok();
        }
    }
}
