using EJ15.Tournament.ServiceLibrary.Contracts.Contract;
using EJ15.Tournament.WebApi.Mappers.Pokemon;
using EJ15.Tournament.WebApi.Models.Response.Pokemon;
using System.Threading.Tasks;
using System.Web.Http;

namespace EJ15.Tournament.WebApi.Controllers
{
    /// <summary>
    /// Controller to manage Pokemon information
    /// </summary>
    [RoutePrefix("api/Pokemon")]
    public class PokemonController : ApiController
    {
        private readonly IPokemonService _pokemonService;
        private readonly IPokemonMapper _mapper;

        public PokemonController(IPokemonService pokemonService, IPokemonMapper mapper)
        {
            _pokemonService = pokemonService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get Pokemon by Id
        /// </summary>
        /// <param name="id">Pokemon Id</param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetPokemon/{id}")]
        public async Task<IHttpActionResult> GetPokemonAsync(int id) 
        {
            var pokemon = await _pokemonService.GetPokemonAsync(id).ConfigureAwait(false);
            if (pokemon == null) return BadRequest();
            var result = _mapper.ToPokemonResponse(pokemon);
            return Ok(result);
        }

        /// <summary>
        /// Get Type by id
        /// </summary>
        /// <param name="id">Type Id</param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetType/{id}")]
        public async Task<IHttpActionResult> GetTypeAsync(int id) 
        {
            return Ok(new TypeResponse());
        }

        /// <summary>
        /// Get Move by Id
        /// </summary>
        /// <param name="id">Move Id</param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetMove/{id}")]
        public async Task<IHttpActionResult> GetMoveAsync(int id) 
        {
            var move = await _pokemonService.GetMoveAsync(id).ConfigureAwait(false);
            if (move == null) return BadRequest();
            var result = _mapper.ToMoveResponse(move);
            return Ok(result);
        }
    }
}
