using EFCodeFirst.WebApi.Infrastructure;
using EFCodeFirst.WebApi.Models;
using System.Web.Http;

namespace EFCodeFirst.WebApi.Controllers
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
        public IHttpActionResult Post(EFRequest request)
        {
            return Ok(_EfRepository.Insert(request));
        }

        [HttpPut]
        [Route("Put/{id}")]
        public IHttpActionResult Put(int id, EFRequest request)
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
