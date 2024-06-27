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
    public class PokemonRepository : IPokemonRepository
    {
        private readonly MyPokemonContext _context;
        private readonly IMemoryCache _cache;
        private const string CacheKeyPrefix = "pokemon_";
        public PokemonRepository(MyPokemonContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }
        public async Task AddAsync(Pokemon pokemon)
        {
            _context.Pokemons.Add(pokemon);
            await _context.SaveChangesAsync();
            await InvalidateCacheAsync();
        }

        public async Task<IEnumerable<Pokemon>> GetAllAsync(int pageNumber, int pageSize, string search)
        {
            // Tạo cache key dựa trên pageNumber, pageSize và search để lưu vào bộ nhớ cache
            string cacheKey = $"{CacheKeyPrefix}list_{pageNumber}_{pageSize}_{search}";

            // Kiểm tra xem cache có giá trị cho cacheKey không
            if (!_cache.TryGetValue(cacheKey, out IEnumerable<Pokemon> pokemons))
            {
                var query = _context.Pokemons
                    .Where(p => !p.IsDeleted && (string.IsNullOrEmpty(search) || p.Name.Contains(search)))
                    .Include(p => p.PokemonTypes)
                        .ThenInclude(pt => pt.PType)
                    .OrderBy(p => p.Id);

                pokemons = await query
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                // Cấu hình cache
                var cacheOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1)
                };

                _cache.Set(cacheKey, pokemons, cacheOptions);
            }

            return pokemons;
        }

        public async Task<int> GetTotalCountAsync(string search)
        {
            string cacheKey = $"{CacheKeyPrefix}count_{search}";
            if (!_cache.TryGetValue(cacheKey, out int totalCount))
            {
                totalCount = await _context.Pokemons
                    .Where(p => !p.IsDeleted && (string.IsNullOrEmpty(search) || p.Name.Contains(search)))
                    .CountAsync();

                var cacheOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1)
                };
                _cache.Set(cacheKey, totalCount, cacheOptions);
            }
            return totalCount;
        }
        public async Task<Pokemon> GetByIdAsync(int id)
        {
            string cacheKey = $"{CacheKeyPrefix}pokemon_{id}";

            if (!_cache.TryGetValue(cacheKey, out Pokemon pokemon))
            {
                pokemon = await _context.Pokemons
                    .Include(p => p.PokemonTypes)
                    .ThenInclude(pt => pt.PType)
                    .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);

                if (pokemon != null)
                {
                    // Cấu hình cache
                    var cacheOptions = new MemoryCacheEntryOptions
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1)
                    };

                    _cache.Set(cacheKey, pokemon, cacheOptions);
                }
            }

            return pokemon;
        }

        public async Task SoftDeleteAsync(int id)
        {
            var pokemon = await _context.Pokemons.FindAsync(id);
            if (pokemon != null)
            {
                pokemon.IsDeleted = true;
                pokemon.UpdatedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                await InvalidateCacheByIdAsync(id);
                await InvalidateCacheAsync();
            }
        }


        public async Task UpdateAsync(Pokemon pokemon)
        {
            _context.Entry(pokemon).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            await InvalidateCacheByIdAsync(pokemon.Id);
            await InvalidateCacheAsync();
        }

        public async Task InvalidateCacheAsync()
        {
            _cache.Remove($"{CacheKeyPrefix}list_1_10_");
            _cache.Remove($"{CacheKeyPrefix}count_");
        }

        public async Task InvalidateCacheByIdAsync(int id)
        {
            string cacheKey = $"{CacheKeyPrefix}pokemon_{id}";
            _cache.Remove(cacheKey);
        }

    }
}
