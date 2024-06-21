using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPokemon.Domain.Entities
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string? Name { get; set; } = "";
        public float Height_m { get; set; }
        public float Weight_kg { get; set; }
        public ICollection<Pokemon_Type> PokemonTypes { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
