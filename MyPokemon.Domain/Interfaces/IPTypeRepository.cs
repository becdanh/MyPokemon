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
        Task<(IEnumerable<Pokemon>, int)> GetPokemonsByTypeAsync(int id, int pageNumber, int pageSize);
        Task <bool> ExistsAsync(int id);
        Task<bool> ExistsPTypeAsync(string slug);
        Task AddAsync(PType pType);
        Task<(IEnumerable<PType>, int)> GetAllAsync(int pageNumber, int pageSize, string search);
        Task UpdateAsync(PType pType);
        Task SoftDeleteAsync(int id);
    }
}
