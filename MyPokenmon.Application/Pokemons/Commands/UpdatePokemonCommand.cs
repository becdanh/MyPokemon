using MediatR;
using MyPokemon.Application.Common;
using MyPokemon.Application.Pokemons.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPokemon.Application.Pokemons.Commands
{
    public class UpdatePokemonCommand : IRequest<ApiResponse<ItemResult<PokemonDto>>>
    {
        public int id { get; set; }
        public string name { get; set; }
        public float height_M { get; set; }
        public float weight_Kg { get; set; }
        public List<int> typeIds { get; set; }
    }
}
