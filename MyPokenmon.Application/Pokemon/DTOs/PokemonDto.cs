using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPokemon.Application.Pokemon.DTOs
{
    public class PokemonDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Height_m { get; set; }
        public float Weight_kg { get; set; }
        public List<string> PTypes { get; set; }
    }
}
