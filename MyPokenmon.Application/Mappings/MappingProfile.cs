using AutoMapper;
using MyPokemon.Application.Helper;
using MyPokemon.Application.Pokemons.Commands;
using MyPokemon.Application.Pokemons.DTOs;
using MyPokemon.Application.Ptypes.Commands;
using MyPokemon.Application.Ptypes.DTOs;
using MyPokemon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPokemon.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Pokemon, PokemonDto>()
           .ForMember(dest => dest.pokemonTypes, opt => opt.MapFrom(src =>
               src.PokemonTypes.Select(pt => pt.PType.Name).ToList()
           ));

            CreateMap<CreatePokemonCommand, Pokemon>()
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.name))
               .ForMember(dest => dest.Height_m, opt => opt.MapFrom(src => src.heightM))
               .ForMember(dest => dest.Weight_kg, opt => opt.MapFrom(src => src.weightKg))
               .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => false))
               .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
               .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
               .ForMember(dest => dest.PokemonTypes, opt => opt.Ignore());

            CreateMap<UpdatePokemonCommand, Pokemon>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.name))
                .ForMember(dest => dest.Height_m, opt => opt.MapFrom(src => src.heightM))
                .ForMember(dest => dest.Weight_kg, opt => opt.MapFrom(src => src.weightKg))
                .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => false))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.PokemonTypes, opt => opt.Ignore());

            CreateMap<PType, PtypeDto>();

            CreateMap<CreatePTypeCommand, PType>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.name))
                .ForMember(dest => dest.Slug, opt => opt.MapFrom(src => Utilities.GenerateSlug(src.name)))
                .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => false))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));

            CreateMap<UpdatePTypeCommand, PType>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.name))
            .ForMember(dest => dest.Slug, opt => opt.MapFrom(src => Utilities.GenerateSlug(src.name)))
            .ForMember(dest => dest.IsDeleted, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));
        }
    }
}
