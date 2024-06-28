using MediatR;
using MyPokemon.Application.Common;
using MyPokemon.Application.Pokemons.DTOs;
using MyPokemon.Application.Ptypes.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPokemon.Application.Ptypes.Commands
{
    public class UpdatePTypeCommand : IRequest<ApiResponse<ItemResult<PtypeDto>>>
    {
        public int id { get; set; }
        public string? name { get; set; } = "";
    }
}
