using AutoMapper;
using MediatR;
using MyPokemon.Application.Common;
using MyPokemon.Application.Pokemons.Commands;
using MyPokemon.Application.Pokemons.DTOs;
using MyPokemon.Application.Ptypes.Commands;
using MyPokemon.Application.Ptypes.DTOs;
using MyPokemon.Domain.Entities;
using MyPokemon.Domain.Interfaces;
using MyPokemon.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPokemon.Application.Ptypes.Handlers
{
    public class UpdatePTypeCommandHandler : IRequestHandler<UpdatePTypeCommand, ApiResponse<ItemResult<PtypeDto>>>
    {
        private readonly IPTypeRepository _pTypeRepository;
        private readonly IMapper _mapper;
        public UpdatePTypeCommandHandler(IPTypeRepository pTypeRepository, IMapper mapper)
        {
            _pTypeRepository = pTypeRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<ItemResult<PtypeDto>>> Handle(UpdatePTypeCommand request, CancellationToken cancellationToken)
        {
            var type = await _pTypeRepository.GetByIdAsync(request.id);
            if (type == null || type.IsDeleted)
            {
                return new ApiResponse<ItemResult<PtypeDto>>
                {
                    Success = false,
                    Error = new ApiError
                    {
                        Code = 0,
                        Message = $"PType with ID {request.id} not found."
                    }
                };
            }

            _mapper.Map(request, type);

            await _pTypeRepository.UpdateAsync(type);

            var typeDto = _mapper.Map<PtypeDto>(type);

            return new ApiResponse<ItemResult<PtypeDto>>
            {
                Success = true,
                Error = null,
                Result = new ItemResult<PtypeDto>
                {
                    Item = typeDto
                }
            };
        }
    }
}
