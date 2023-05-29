using ADOCodeSample.WebApi.Infrastructure;
using ADOCodeSample.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ADOCodeSample.WebApi.Controllers
{
    [RoutePrefix("api/Ado")]
    public class AdoController : ApiController
    {
        private readonly AdoRepository _adosRepository;

        public AdoController()
        {
            _adosRepository= new AdoRepository();
        }

        [HttpGet]
        [Route("Get")]
        public IHttpActionResult Get() 
        {
            return Ok(_adosRepository.GetAll());
        }

        [HttpPost]
        [Route("Post")]
        public IHttpActionResult Post(AdoRequest request) 
        {
            return Ok(_adosRepository.Insert(request));
        }

        [HttpPut]
        [Route("Put")]
        public IHttpActionResult Put(AdoRequest request) 
        {
            return Ok(_adosRepository.Update(request));
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public IHttpActionResult Delete(int id) 
        {
            return Ok(_adosRepository.Delete(id));
        }
    }
}