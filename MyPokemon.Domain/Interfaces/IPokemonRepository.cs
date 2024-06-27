using MyPokemon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPokemon.Domain.Interfaces
{
    public interface IPokemonRepository
    {
        Task AddAsync(Pokemon pokemon);
        Task<Pokemon> GetByIdAsync(int id);
        Task<IEnumerable<Pokemon>> GetAllAsync(int pageNumber, int pageSize, string search);
        Task<int> GetTotalCountAsync(string search);
        Task UpdateAsync(Pokemon pokemon);
        Task SoftDeleteAsync(int id);
        Task InvalidateCacheAsync();
        Task InvalidateCacheByIdAsync(int id);
    }
}
