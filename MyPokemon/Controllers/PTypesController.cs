using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyPokemon.Application.Pokemons.DTOs;
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
    }
}
