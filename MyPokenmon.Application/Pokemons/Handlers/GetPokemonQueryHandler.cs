using AutoMapper;
using MediatR;
using MyPokemon.Application.Common;
using MyPokemon.Application.Pokemons.DTOs;
using System.Threading;
using System.Threading.Tasks;
using MyPokemon.Domain.Interfaces;
using MyPokemon.Application.Pokemons.Queries;

namespace MyPokemon.Application.Pokemons.Handlers
{
    public class GetPokemonQueryHandler : IRequestHandler<GetPokemonQuery, ApiResponse<ItemResult<PokemonDto>>>
    {
        private readonly IPokemonRepository _pokemonRepository;
        private readonly IMapper _mapper;

        public GetPokemonQueryHandler(IPokemonRepository pokemonRepository, IMapper mapper)
        {
            _pokemonRepository = pokemonRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<ItemResult<PokemonDto>>> Handle(GetPokemonQuery request, CancellationToken cancellationToken)
        {
            var pokemon = await _pokemonRepository.GetByIdAsync(request.PokemonId);

            if (pokemon == null)
            {
                return new ApiResponse<ItemResult<PokemonDto>>
                {
                    Success = false,
                    Error = "Pokemon not found",
                    Result = null
                };
            }

            var pokemonDto = _mapper.Map<PokemonDto>(pokemon);

            return new ApiResponse<ItemResult<PokemonDto>>
            {
                Success = true,
                Error = null,
                Result = new ItemResult<PokemonDto>
                {
                    Item = pokemonDto
                }
            };
        }
    }
}
