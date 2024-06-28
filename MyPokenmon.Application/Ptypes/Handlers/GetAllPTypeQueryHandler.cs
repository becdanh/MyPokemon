using AutoMapper;
using MediatR;
using MyPokemon.Application.Common;
using MyPokemon.Application.Pokemons.DTOs;
using MyPokemon.Application.Pokemons.Queries;
using MyPokemon.Application.Ptypes.DTOs;
using MyPokemon.Application.Ptypes.Queries;
using MyPokemon.Domain.Interfaces;
using MyPokemon.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPokemon.Application.Ptypes.Handlers
{
    public class GetAllPTypeQueryHandler : IRequestHandler<GetAllPTypeQuery, ApiResponse<PagedResult<PtypeDto>>>
    {
        private readonly IPTypeRepository _pTypeRepository;
        private readonly IMapper _mapper;

        public GetAllPTypeQueryHandler(IPTypeRepository pTypeRepository, IMapper mapper)
        {
            _pTypeRepository = pTypeRepository;
            _mapper = mapper;
        }
        public async Task<ApiResponse<PagedResult<PtypeDto>>> Handle(GetAllPTypeQuery request, CancellationToken cancellationToken)
        {
            var (types, totalCount) = await _pTypeRepository.GetAllAsync(request.pageNumber, request.pageSize, request.search);

            var items = _mapper.Map<IEnumerable<PtypeDto>>(types).ToList();

            return new ApiResponse<PagedResult<PtypeDto>>
            {
                Success = true,
                Result = new PagedResult<PtypeDto>
                {
                    TotalCount = totalCount,
                    Items = items
                }
            };
        }
    }
}
