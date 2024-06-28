using MediatR;
using MyPokemon.Application.Common;
using MyPokemon.Application.Pokemons.DTOs;
using MyPokemon.Application.Ptypes.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPokemon.Application.Ptypes.Queries
{
    public class GetPTypeQuery : IRequest<ApiResponse<ItemResult<PtypeDto>>>
    {
        public int pTypeId { get; set; }
        public GetPTypeQuery(int PTypeId)
        {
            pTypeId = PTypeId;
        }
    }
}
