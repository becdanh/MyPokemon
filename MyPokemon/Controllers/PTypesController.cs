using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyPokemon.Application.Common;
using MyPokemon.Application.Pokemons.Commands;
using MyPokemon.Application.Pokemons.DTOs;
using MyPokemon.Application.Pokemons.Queries;
using MyPokemon.Application.Ptypes.Commands;
using MyPokemon.Application.Ptypes.Queries;

namespace MyPokemon.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PTypesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PTypesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("ListPokemonByType")]
        public async Task<ActionResult<List<PokemonDto>>> GetPokemonsByTypeId(int typeId, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 15)
        {
            var query = new GetPokemonsByTypeQuery(typeId, pageNumber, pageSize);
            var response = await _mediator.Send(query);

            if (!response.Success)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpGet("GetPokemonTypeDetail")]
        public async Task<IActionResult> GetType(int pokemonTypeId)
        {
            var query = new GetPTypeQuery(pokemonTypeId);
            var result = await _mediator.Send(query);

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }

        [HttpPost("Create")]
        public async Task<ActionResult> CreatePType([FromBody] CreatePTypeCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllPTypes([FromQuery] string search = "", [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var query = new GetAllPTypeQuery(search, pageNumber, pageSize);

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<ActionResult> UpdatePType([FromBody] UpdatePTypeCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult> SoftDelete(int id)
        {
            var command = new DeletePTypeCommand(id);
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
