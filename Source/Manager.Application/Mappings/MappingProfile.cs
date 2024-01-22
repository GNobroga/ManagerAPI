using AutoMapper;
using Manager.Application.DTOs;
using Manager.Domain.Entities;

namespace Manager.Application.Mappings
{
    public sealed class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}