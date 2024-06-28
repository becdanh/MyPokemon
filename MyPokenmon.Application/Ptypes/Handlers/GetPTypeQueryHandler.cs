using AutoMapper;
using MediatR;
using MyPokemon.Application.Common;
using MyPokemon.Application.Pokemons.DTOs;
using MyPokemon.Application.Pokemons.Queries;
using MyPokemon.Application.Ptypes.DTOs;
using MyPokemon.Application.Ptypes.Queries;
using MyPokemon.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPokemon.Application.Ptypes.Handlers
{
    public class GetPTypeQueryHandler : IRequestHandler<GetPTypeQuery, ApiResponse<ItemResult<PtypeDto>>>
    {
        private readonly IPTypeRepository _pTypeRepository;
        private readonly IMapper _mapper;

        public GetPTypeQueryHandler(IPTypeRepository pTypeRepository, IMapper mapper)
        {
            _pTypeRepository = pTypeRepository;
            _mapper = mapper;
        }
        public async Task<ApiResponse<ItemResult<PtypeDto>>> Handle(GetPTypeQuery request, CancellationToken cancellationToken)
        {
            var type = await _pTypeRepository.GetByIdAsync(request.pTypeId);

            if (type == null)
            {
                return new ApiResponse<ItemResult<PtypeDto>>
                {
                    Success = false,
                    Error = new ApiError
                    {
                        Code = 0,
                        Message = $"PType with ID {request.pTypeId} not found"
                    },
                    Result = null
                };
            }

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
