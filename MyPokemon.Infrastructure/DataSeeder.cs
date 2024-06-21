using Microsoft.EntityFrameworkCore;
using MyPokemon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPokemon.Infrastructure
{
    public class DataSeeder
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            // Seed PType data
            var types = new List<PType>
            {
                new PType { Id = 1, Name = "Fire", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new PType { Id = 2, Name = "Water", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new PType { Id = 3, Name = "Grass", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new PType { Id = 4, Name = "Flying", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now }
            };

            modelBuilder.Entity<PType>().HasData(types);

            // Seed Pokemon data
            var pokemons = new List<Pokemon>
            {
                new Pokemon { Id = 1, Name = "Charmander", Height_m = 0.6f, Weight_kg = 8.5f, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Pokemon { Id = 2, Name = "Squirtle", Height_m = 0.5f, Weight_kg = 9.0f, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Pokemon { Id = 3, Name = "Bulbasaur", Height_m = 0.7f, Weight_kg = 6.9f, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Pokemon { Id = 4, Name = "Charizard", Height_m = 1.7f, Weight_kg = 90.5f, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now }
            };

            modelBuilder.Entity<Pokemon>().HasData(pokemons);

            // Seed Pokemon_Type data
            var pokemonTypes = new List<Pokemon_Type>
            {
                new Pokemon_Type { PokemonId = 1, TypeId = 1 },
                new Pokemon_Type { PokemonId = 2, TypeId = 2 },
                new Pokemon_Type { PokemonId = 3, TypeId = 3 },
                new Pokemon_Type { PokemonId = 4, TypeId = 1 },
                new Pokemon_Type { PokemonId = 4, TypeId = 4 } // Charizard has both Fire and Flying types
            };

            modelBuilder.Entity<Pokemon_Type>().HasData(pokemonTypes);
        }
    }
}
