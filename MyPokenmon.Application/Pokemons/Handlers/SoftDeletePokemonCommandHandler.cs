﻿using MediatR;
using MyPokemon.Application.Common;
using MyPokemon.Application.Pokemons.Commands;
using MyPokemon.Application.Pokemons.DTOs;
using MyPokemon.Domain.Entities;
using MyPokemon.Domain.Interfaces;
using MyPokemon.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPokemon.Application.Pokemons.Handlers
{
    public class SoftDeletePokemonCommandHandler : IRequestHandler<SoftDeletePokemonCommand, ApiResponse<ItemResult<Pokemon>>>
    {
        private readonly IPokemonRepository _pokemonRepository;

        public SoftDeletePokemonCommandHandler(IPokemonRepository pokemonRepository)
        {
            _pokemonRepository = pokemonRepository;
        }

        public async Task<ApiResponse<ItemResult<Pokemon>>> Handle(SoftDeletePokemonCommand request, CancellationToken cancellationToken)
        {
            var pokemon = await _pokemonRepository.GetByIdAsync(request.id);
            if (pokemon == null || pokemon.IsDeleted)
            {
                return new ApiResponse<ItemResult<Pokemon>>
                {
                    Success = false,
                    Error = "Pokemon not found"
                };
            }

            await _pokemonRepository.SoftDeleteAsync(request.id);

            return new ApiResponse<ItemResult<Pokemon>>
            {
                Success = true,
                Error = null,
                Result = null
            };
        }
    }
}