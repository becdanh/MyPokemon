using AutoMapper;
using MediatR;
using MyPokemon.Application.Common;
using MyPokemon.Application.Pokemons.DTOs;
using MyPokemon.Application.Ptypes.Queries;
using MyPokemon.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPokemon.Application.Ptypes.Handlers
{
    public class GetPokemonsByTypeQueryHandler : IRequestHandler<GetPokemonsByTypeQuery, ApiResponse<PagedResult<PokemonDto>>>
    {
        private readonly IPTypeRepository _pTypeRepository;
        private readonly IMapper _mapper;

        public GetPokemonsByTypeQueryHandler(IPTypeRepository pTypeRepository, IMapper mapper)
        {
            _pTypeRepository = pTypeRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<PagedResult<PokemonDto>>> Handle(GetPokemonsByTypeQuery request, CancellationToken cancellationToken)
        {
            var pType = await _pTypeRepository.GetByIdAsync(request.typeId);
            if (pType == null)
            {
                return new ApiResponse<PagedResult<PokemonDto>>
                {
                    Success = false,
                    Error = new ApiError
                    {
                        Code = 1,
                        Message = "There isn't a Pokémon type matching this typeId."
                    }
                };
            }

            var (pokemons, totalCount) = await _pTypeRepository.GetPokemonsByTypeAsync(request.typeId, request.pageNumber, request.pageSize);

            var items = _mapper.Map<IEnumerable<PokemonDto>>(pokemons).ToList();

            return new ApiResponse<PagedResult<PokemonDto>>
            {
                Success = true,
                Result = new PagedResult<PokemonDto>
                {
                    Items = items,
                    TotalCount = totalCount
                }
            };
        }
    }
}
