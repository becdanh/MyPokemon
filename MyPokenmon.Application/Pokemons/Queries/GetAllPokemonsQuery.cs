using MediatR;
using MyPokemon.Application.Common;
using MyPokemon.Application.Pokemons.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAPI.Application.Common;

namespace MyPokemon.Application.Pokemons.Queries
{
    public class GetAllPokemonsQuery : IRequest<ApiResponse<PagedResult<PokemonDto>>>
    {
        public string? Search { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
