using MediatR;
using MyPokemon.Application.Pokemon.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAPI.Application.Common;

namespace MyPokemon.Application.Pokemon.Queries
{
    public class GetAllPokemonsQuery : IRequest<PagedList<PokemonDto>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 15;
    }
}
