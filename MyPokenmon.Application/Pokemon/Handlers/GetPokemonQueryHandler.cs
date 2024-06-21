using MediatR;
using MyPokemon.Application.Common;
using MyPokemon.Application.Pokemon.DTOs;
using MyPokemon.Application.Pokemon.Queries;
using MyPokemon.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPokemon.Application.Pokemon.Handlers
{
    public class GetPokemonQueryHandler : IRequestHandler<GetPokemonQuery, ApiResponse<PokemonDto>>
    {
        private readonly IPokemonRepository _pokemonRepository;

        public GetPokemonQueryHandler(IPokemonRepository pokemonRepository)
        {
            _pokemonRepository = pokemonRepository;
        }
        public async Task<ApiResponse<PokemonDto>> Handle(GetPokemonQuery request, CancellationToken cancellationToken)
        {
            var pokemon = await _pokemonRepository.GetByIdAsync(request.PokemonId);

            if (pokemon == null)
            {
                return new ApiResponse<PokemonDto>
                {
                    Success = false,
                    Error = new ApiError
                    {
                        Message = "Pokemon not found",
                        Details = null
                    }
                };
            }

            // Chuyển đổi từ entity Order sang DTO OrderDto
            var pokemonDto = new PokemonDto
            {
                Id = pokemon.Id,
                Name = pokemon.Name,
                Height_m = pokemon.Height_m,
                Weight_kg = pokemon.Weight_kg,
                PTypes = pokemon.PokemonTypes.Select(pt => pt.PType.Name).ToList()
            };

            return new ApiResponse<PokemonDto>
            {
                Result = pokemonDto,
                Success = true
            };
/*            return pokemonDto;*/
        }
    }
}
