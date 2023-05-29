using HiveApp.ServiceLibrary.Contracts.Contracts;
using HiveApp.WebApi.Mappers;
using HiveApp.WebApi.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HiveApp.WebApi.Controllers
{
    [RoutePrefix("api/bees")]
    public class BeeController : ApiController
    {
        private readonly IBeeService _beeService;
        private readonly IResponseMapper _mapper;
        public BeeController(IBeeService beeService, IResponseMapper responseMapper)
        {
            _beeService = beeService;
            _mapper = responseMapper;
        }

        [HttpGet]
        [Route("get")]
        public IHttpActionResult GetAllBees()
        {
            return Ok(_mapper.ToBeeResponseList(_beeService.GetBeeList()));
        }

        [HttpPost]
        [Route("post")]
        public IHttpActionResult CreateBee(BeeRequest request)
        {
            return Ok(_beeService.PostBee(_mapper.ToBeeEntity(request)));
        }
    }
}
