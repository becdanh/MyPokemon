using MediatR;
using MyPokemon.Application.Common;
using MyPokemon.Application.Pokemons.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPokemon.Application.Pokemons.Queries
{
    public class GetPokemonQuery : IRequest<ApiResponse<ItemResult<PokemonDto>>>
    {
        public int PokemonId { get; set; }
        public GetPokemonQuery(int pokemonId)
        {
            PokemonId = pokemonId;
        }
    }
}
