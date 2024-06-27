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

    }
}
