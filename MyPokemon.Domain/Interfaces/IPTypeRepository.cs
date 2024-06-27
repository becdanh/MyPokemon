using MyPokemon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPokemon.Domain.Interfaces
{
    public interface IPTypeRepository
    {
        Task<PType> GetByIdAsync(int id);
    }
}
