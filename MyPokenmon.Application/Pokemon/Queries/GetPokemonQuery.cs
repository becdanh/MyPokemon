using MediatR;
using MyPokemon.Application.Common;
using MyPokemon.Application.Pokemon.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPokemon.Application.Pokemon.Queries
{
    public class GetPokemonQuery : IRequest<ApiResponse<PokemonDto>>
    {
        public int PokemonId { get; set; }
        public GetPokemonQuery(int pokemonId)
        {
            PokemonId = pokemonId;
        }
    }
}
