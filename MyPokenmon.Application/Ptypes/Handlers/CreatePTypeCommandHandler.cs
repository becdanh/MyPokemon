using AutoMapper;
using MediatR;
using MyPokemon.Application.Common;
using MyPokemon.Application.Helper;
using MyPokemon.Application.Pokemons.Commands;
using MyPokemon.Application.Pokemons.DTOs;
using MyPokemon.Application.Ptypes.Commands;
using MyPokemon.Application.Ptypes.DTOs;
using MyPokemon.Domain.Entities;
using MyPokemon.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPokemon.Application.Ptypes.Handlers
{
    public class CreatePtypeCommandHandler : IRequestHandler<CreatePTypeCommand, ApiResponse<ItemResult<PtypeDto>>>
    {
        private readonly IPTypeRepository _pTypeRepository;
        private readonly IMapper _mapper;

        public CreatePtypeCommandHandler(IPTypeRepository pTypeRepository, IMapper mapper)
        {
            _pTypeRepository = pTypeRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<ItemResult<PtypeDto>>> Handle(CreatePTypeCommand request, CancellationToken cancellationToken)
        {
            var slug = Utilities.GenerateSlug(request.name);

            // Check if a PType with the same slug already exists
            if (await _pTypeRepository.ExistsPTypeAsync(slug))
            {
                return new ApiResponse<ItemResult<PtypeDto>>
                {
                    Success = false,
                    Error = new ApiError
                    {
                        Code = 1,
                        Message = $"A Pokémon type with name '{request.name}' already exists."
                    }
                };
            }
            var type = _mapper.Map<PType>(request);

            await _pTypeRepository.AddAsync(type);

            var pTypeDto = _mapper.Map<PtypeDto>(type);

            return new ApiResponse<ItemResult<PtypeDto>>
            {
                Success = true,
                Error = null,
                Result = new ItemResult<PtypeDto>
                {
                    Item = pTypeDto
                }
            };
        }
    }
}
