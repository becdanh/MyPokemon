using MediatR;
using MyPokemon.Application.Common;
using MyPokemon.Application.Pokemons.DTOs;
using MyPokemon.Application.Ptypes.DTOs;
using MyPokemon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPokemon.Application.Ptypes.Queries
{
    public class GetAllPTypeQuery : IRequest<ApiResponse<PagedResult<PtypeDto>>>
    {
        public string? search { get; set; }
        public int pageNumber { get; set; }
        public int pageSize { get; set; }
        public GetAllPTypeQuery(string Search, int PageNumber, int PageSize)
        {
            search = Search;
            pageNumber = PageNumber;
            pageSize = PageSize;
        }
    }
}
