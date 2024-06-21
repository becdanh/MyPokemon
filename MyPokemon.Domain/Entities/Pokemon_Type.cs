using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPokemon.Domain.Entities
{
    public class Pokemon_Type
    {
        public int PokemonId { get; set; }
        public int TypeId { get; set; }
        public Pokemon Pokemon { get; set; }
        public PType PType { get; set; }
    }
}
