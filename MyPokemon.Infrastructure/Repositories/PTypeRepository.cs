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
    public class PTypeRepository : IPTypeRepository
    {
        private readonly MyPokemonContext _context;

        public PTypeRepository(MyPokemonContext context)
        {
            _context = context;
        }
        public async Task<PType> GetByIdAsync(int id)
        {
            return await _context.PTypes.FindAsync(id);
        }

        public async Task<(IEnumerable<Pokemon>, int)> GetPokemonsByTypeAsync(int id, int pageNumber, int pageSize)
        {
            var query = _context.Pokemons
                .Where(p => !p.IsDeleted && p.PokemonTypes.Any(pt => pt.TypeId == id))
                .Include(p => p.PokemonTypes)
                    .ThenInclude(pt => pt.PType);

            var pokemons = await query
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();
            var totalCount = await query.CountAsync();

            return (pokemons, totalCount);
        }

    }
}
