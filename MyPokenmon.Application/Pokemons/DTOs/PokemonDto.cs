using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPokemon.Application.Pokemons.DTOs
{
    public class PokemonDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float height_M { get; set; }
        public float weight_Kg { get; set; }
        public List<string> pokemonTypes { get; set; }
    }
}
