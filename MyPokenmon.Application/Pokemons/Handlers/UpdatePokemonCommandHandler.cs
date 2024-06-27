using AutoMapper;
using MediatR;
using MyPokemon.Application.Common;
using MyPokemon.Application.Pokemons.Commands;
using MyPokemon.Application.Pokemons.DTOs;
using MyPokemon.Domain.Entities;
using MyPokemon.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPokemon.Application.Pokemons.Handlers
{
    public class UpdatePokemonCommandHandler : IRequestHandler<UpdatePokemonCommand, ApiResponse<ItemResult<PokemonDto>>>
    {
        private readonly IPokemonRepository _pokemonRepository;
        private readonly IPTypeRepository _pTypeRepository;
        private readonly IMapper _mapper;
        public UpdatePokemonCommandHandler(IPokemonRepository pokemonRepository, IPTypeRepository pTypeRepository, IMapper mapper)
        {
            _pokemonRepository = pokemonRepository;
            _pTypeRepository = pTypeRepository;
            _mapper = mapper;
        }
        public async Task<ApiResponse<ItemResult<PokemonDto>>> Handle(UpdatePokemonCommand request, CancellationToken cancellationToken)
        {
            var pokemon = await _pokemonRepository.GetByIdAsync(request.id);
            if (pokemon == null || pokemon.IsDeleted)
            {
                return new ApiResponse<ItemResult<PokemonDto>>
                {
                    Success = false,
                    Error = "Pokemon not found"
                };
            }

            _mapper.Map(request, pokemon);

            pokemon.PokemonTypes.Clear();
            foreach (var typeId in request.typeIds)
            {
                var type = await _pTypeRepository.GetByIdAsync(typeId);
                if (type != null)
                {
                    pokemon.PokemonTypes.Add(new Pokemon_Type { PType = type });
                }
            }

            await _pokemonRepository.UpdateAsync(pokemon);

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
