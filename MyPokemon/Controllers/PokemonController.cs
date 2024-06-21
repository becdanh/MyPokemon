using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyPokemon.Application.Pokemon.Queries;

namespace MyPokemon.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {

        private readonly IMediator _mediator;
        public PokemonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetPokemons([FromQuery] GetAllPokemonsQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("GetPokemonDetail")]
        public async Task<IActionResult> GetPokemon(int pokemonId)
        {
            var query = new GetPokemonQuery(pokemonId);
            var response = await _mediator.Send(query);

            return Ok(response);
        }
    }
}
