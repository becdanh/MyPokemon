using MediatR;
using MyPokemon.Application.Common;
using MyPokemon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPokemon.Application.Ptypes.Commands
{
    public class DeletePTypeCommand : IRequest<ApiResponse<ItemResult<PType>>>
    {
        public int id { get; set; }
        public DeletePTypeCommand (int Id)
        {
            id = Id; 
        }
    }
}
