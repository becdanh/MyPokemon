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
        IQueryable<Pokemon> GetAll();
        Task UpdateAsync(Pokemon pokemon);
        Task SoftDeleteAsync(int id);
    }
}
