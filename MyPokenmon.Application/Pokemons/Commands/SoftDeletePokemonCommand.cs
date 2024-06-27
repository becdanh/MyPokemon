using MediatR;
using MyPokemon.Application.Common;
using MyPokemon.Application.Pokemons.DTOs;
using MyPokemon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPokemon.Application.Pokemons.Commands
{
    public class SoftDeletePokemonCommand : IRequest<ApiResponse<ItemResult<Pokemon>>>
    {
        public int id { get; set; }
    }
}
