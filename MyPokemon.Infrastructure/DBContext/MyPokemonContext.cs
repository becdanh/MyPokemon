using Microsoft.EntityFrameworkCore;
using MyPokemon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPokemon.Infrastructure.DBContext
{
    public class MyPokemonContext : DbContext
    {
        public MyPokemonContext(DbContextOptions<MyPokemonContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pokemon_Type>()
                    .HasKey(pc => new { pc.PokemonId, pc.TypeId });
            modelBuilder.Entity<Pokemon_Type>()
                    .HasOne(p => p.Pokemon)
                    .WithMany(pc => pc.PokemonTypes)
                    .HasForeignKey(p => p.PokemonId);
            modelBuilder.Entity<Pokemon_Type>()
                    .HasOne(p => p.PType)
                    .WithMany(pc => pc.PokemonTypes)
                    .HasForeignKey(c => c.TypeId);

/*            DataSeeder.SeedData(modelBuilder);*/
        }

        public DbSet<Pokemon> Pokemons { get; set; }
        public DbSet<PType> PTypes { get; set; }
        public DbSet<Pokemon_Type> PokemonTypes { get; set; }
    }
}
