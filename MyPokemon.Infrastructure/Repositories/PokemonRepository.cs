using Microsoft.EntityFrameworkCore;
using MyPokemon.Domain.Entities;
using MyPokemon.Domain.Interfaces;
using MyPokemon.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPokemon.Infrastructure.Repositories
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly MyPokemonContext _context;

        public PokemonRepository(MyPokemonContext context)
        {
            _context = context;
        }
        public Task AddAsync(Pokemon pokemon)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Pokemon> GetAll()
        {
            return _context.Pokemons.Where(p => !p.IsDeleted).Include(p => p.PokemonTypes)
            .ThenInclude(pt => pt.PType);
        }

        public async Task<Pokemon> GetByIdAsync(int id)
        {
            return await _context.Pokemons
               .Include(p => p.PokemonTypes)
               .ThenInclude(pt => pt.PType)
               .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);
        }

        public Task SoftDeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Pokemon pokemon)
        {
            throw new NotImplementedException();
        }
    }
}
