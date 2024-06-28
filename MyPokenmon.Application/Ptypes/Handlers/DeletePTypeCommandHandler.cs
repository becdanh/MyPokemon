using AutoMapper;
using MediatR;
using MyPokemon.Application.Common;
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
    public class DeletePTypeCommandHandler : IRequestHandler<DeletePTypeCommand, ApiResponse<ItemResult<PType>>>
    {
        private readonly IPTypeRepository _pTypeRepository;

        public DeletePTypeCommandHandler(IPTypeRepository pTypeRepository)
        {
            _pTypeRepository = pTypeRepository;

        }

        public async Task<ApiResponse<ItemResult<PType>>> Handle(DeletePTypeCommand request, CancellationToken cancellationToken)
        {
            var type = await _pTypeRepository.GetByIdAsync(request.id);
            if (type == null || type.IsDeleted)
            {
                return new ApiResponse<ItemResult<PType>>
                {
                    Success = false,
                    Error = new ApiError
                    {
                        Code = 0,
                        Message = $"PType with ID {request.id} not found."
                    }
                };
            }

            await _pTypeRepository.SoftDeleteAsync(request.id);

            return new ApiResponse<ItemResult<PType>>
            {
                Success = true,
                Error = null,
                Result = null
            };
        }
    }
}
