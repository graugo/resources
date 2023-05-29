using EFHibrid.WebApi.Infrastructure;
using EFHibrid.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EFHibrid.WebApi.Controllers
{
    [RoutePrefix("api/EF")]
    public class EFController : ApiController
    {
        private readonly EFRepository _EfRepository;

        public EFController()
        {
            _EfRepository = new EFRepository();
        }

        [HttpGet]
        [Route("Get")]
        public IHttpActionResult Get()
        {
            return Ok(_EfRepository.GetAll());
        }

        [HttpPost]
        [Route("Post")]
        public IHttpActionResult Post(AdoRequest request)
        {
            return Ok(_EfRepository.Insert(request));
        }

        [HttpPut]
        [Route("Put/{id}")]
        public IHttpActionResult Put(int id, AdoRequest request)
        {
            return Ok(_EfRepository.Update(id, request));
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public IHttpActionResult Delete(int id)
        {
            return Ok(_EfRepository.Delete(id));
        }
    }
}
