using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
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
            return await _context.PTypes
                        .Where(pt => pt.Id == id && pt.IsDeleted == false)
                        .FirstOrDefaultAsync();
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

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.PTypes
                                .AnyAsync(pt => pt.Id == id && pt.IsDeleted == false);
        }

        public async Task<bool> ExistsPTypeAsync(string slug)
        {
            return await _context.PTypes
                                .AnyAsync(pt => pt.Slug == slug && pt.IsDeleted == false);
        }
        public async Task AddAsync(PType pType)
        {
            _context.PTypes.Add(pType);
            await _context.SaveChangesAsync();
        }

        public async Task<(IEnumerable<PType>, int)> GetAllAsync(int pageNumber, int pageSize, string search)
        {
            var query = _context.PTypes
                .Where(p => !p.IsDeleted && (string.IsNullOrEmpty(search) || p.Name.Contains(search)))
                .OrderBy(p => p.Id);

            var types = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var totalCount = await query.CountAsync();

            return (types, totalCount);
        }

        public async Task UpdateAsync(PType pType)
        {
            _context.Entry(pType).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task SoftDeleteAsync(int id)
        {
            var type = await _context.PTypes.FirstOrDefaultAsync(pt => pt.Id == id && !pt.IsDeleted);
            if (type != null)
            {
                type.IsDeleted = true;
                type.UpdatedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
            }
        }
    }
}
