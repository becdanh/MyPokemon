using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyPokemon.Application.Common;
using MyPokemon.Application.Pokemons.Commands;
using MyPokemon.Application.Pokemons.DTOs;
using MyPokemon.Application.Pokemons.Queries;

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
        public async Task<IActionResult> GetAllPokemons([FromQuery] string search = "", [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var query = new GetAllPokemonsQuery
            {
                Search = search,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("GetPokemonDetail")]
        public async Task<IActionResult> GetPokemon(int pokemonId)
        {
            var query = new GetPokemonQuery(pokemonId);
            var result = await _mediator.Send(query);

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }

        [HttpPost("Create")]
        public async Task<ActionResult<int>> CreatePokemon([FromBody] CreatePokemonCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<ActionResult<int>> UpdatePokemon([FromBody] UpdatePokemonCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }

        [HttpPut("Delete")]
        public async Task<ActionResult<ApiResponse<ItemResult<PokemonDto>>>> SoftDelete(int id)
        {
            var command = new SoftDeletePokemonCommand { id = id };
            var result = await _mediator.Send(command);

            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}
