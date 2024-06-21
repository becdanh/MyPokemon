using MediatR;
using MyPokemon.Application.Pokemon.DTOs;
using MyPokemon.Application.Pokemon.Queries;
using MyPokemon.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAPI.Application.Common;

namespace MyPokemon.Application.Pokemon.Handlers
{
    public class GetAllPokemonsQueryHandler : IRequestHandler<GetAllPokemonsQuery, PagedList<PokemonDto>>
    {
        private readonly IPokemonRepository _pokemonRepository;

        public GetAllPokemonsQueryHandler(IPokemonRepository pokemonRepository)
        {
            _pokemonRepository = pokemonRepository;
        }

        public async Task<PagedList<PokemonDto>> Handle(GetAllPokemonsQuery request, CancellationToken cancellationToken)
        {
            var pokemons = _pokemonRepository.GetAll();

            var totalCount = pokemons.Count();

            var items = pokemons
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(p => new PokemonDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Height_m = p.Height_m,
                    Weight_kg = p.Weight_kg,
                    PTypes = p.PokemonTypes.Select(pt => pt.PType.Name).ToList()
                })
                .ToList();

            return new PagedList<PokemonDto>(items, totalCount, request.PageNumber, request.PageSize);

        }
    }
}
