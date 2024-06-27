using MediatR;
using MyPokemon.Application.Common;
using MyPokemon.Application.Pokemons.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPokemon.Application.Ptypes.Queries
{
    public class GetPokemonsByTypeQuery : IRequest<ApiResponse<PagedResult<PokemonDto>>>
    {
        public int typeId { get; set; }
        public int pageNumber { get; set; }
        public int pageSize { get; set; }

        public GetPokemonsByTypeQuery(int id, int PageNumber, int PageSize)
        {
            typeId = id;
            pageNumber = PageNumber;
            pageSize = PageSize;
        }
    }
}
