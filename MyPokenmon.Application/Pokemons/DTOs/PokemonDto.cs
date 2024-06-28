using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPokemon.Application.Pokemons.DTOs
{
    public class PokemonDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public float heightM { get; set; }
        public float weightKg { get; set; }
        public List<string> pokemonTypes { get; set; }
    }
}
