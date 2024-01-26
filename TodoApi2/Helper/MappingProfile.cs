using AutoMapper;
using TodoApi2.Dto;
using TodoApi2.Models;

namespace TodoApi2.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Pokemon, PokemonDto>();
        }


    }
}
