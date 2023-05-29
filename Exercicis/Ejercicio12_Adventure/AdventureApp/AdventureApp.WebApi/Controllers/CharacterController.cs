using AdventureApp.ServiceLibrary.Contracts.Contracts;
using AdventureApp.WebApi.Mappers;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AdventureApp.WebApi.Controllers
{
    [RoutePrefix("api/character")]
    public class CharacterController : ApiController
    {
        private readonly ICharacterService _characterService;
        private readonly ICharacterMapper _mapper;
        private readonly ILog _log;

        public CharacterController(ICharacterService characterService, ICharacterMapper characterMapper, ILog log)
        {
            _characterService = characterService;
            _mapper = characterMapper;
            _log = log;
        }

        [HttpPut]
        [Route("create")]
        public IHttpActionResult CreateCharacter(string name, string characterClass, string key)
        {
            var character = _characterService.CreateCharacter(name, characterClass, key);
            _log.Info("Character created");
            return Ok(_mapper.ToResponse(character));
        }

        [HttpGet]
        [Route("get/{id}")]
        public IHttpActionResult GetCharacter(string id)
        {
            var character = _characterService.GetCharacter(id);
            if (character == null)
            {
                return NotFound();
            }
            return Ok(_mapper.ToResponse(character));
        }
    }
}
