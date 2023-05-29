using MemoryCacheSample.WebApi.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MemoryCacheSample.WebApi.Controllers
{
    [RoutePrefix("api/cache")]
    public class CacheController : ApiController
    {
        private readonly CacheService _cacheService;
        private readonly RedisClient _redisClient;

        public CacheController()
        {
            _cacheService= new CacheService();
            _redisClient= new RedisClient();
        }

        [HttpGet]
        [Route("Get")]
        public IHttpActionResult GetCache() 
        {
            return Ok(_redisClient.GetValue<string>("value"));
        }

        [HttpPost]
        [Route("Set")]
        public IHttpActionResult SetCache() 
        {
            _redisClient.SetValue("value", "hola mundo!");
            return Ok() ;
        }
    }
}
