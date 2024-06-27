using AutoMapper;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using MyPokemon.Application.Common;
using MyPokemon.Application.Pokemons.DTOs;
using MyPokemon.Application.Pokemons.Queries;
using MyPokemon.Domain.Interfaces;
using MyPokemon.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyPokemon.Application.Pokemons.Handlers
{
    public class GetAllPokemonsQueryHandler : IRequestHandler<GetAllPokemonsQuery, ApiResponse<PagedResult<PokemonDto>>>
    {
        private readonly IPokemonRepository _pokemonRepository;

        private readonly IMapper _mapper;

        public GetAllPokemonsQueryHandler(IPokemonRepository pokemonRepository, IMapper mapper)
        {
            _pokemonRepository = pokemonRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<PagedResult<PokemonDto>>> Handle(GetAllPokemonsQuery request, CancellationToken cancellationToken)
        {
            var totalCount = await _pokemonRepository.GetTotalCountAsync(request.Search);
            var pokemons = await _pokemonRepository.GetAllAsync(request.PageNumber, request.PageSize, request.Search);

            var items = _mapper.Map<IEnumerable<PokemonDto>>(pokemons).ToList();

            return new ApiResponse<PagedResult<PokemonDto>>
            {
                Success = true,
                Result = new PagedResult<PokemonDto>
                {
                    TotalCount = totalCount,
                    Items = items
                }
            };
        }
    }
}
