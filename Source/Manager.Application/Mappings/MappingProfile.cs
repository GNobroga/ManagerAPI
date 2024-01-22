using AutoMapper;
using Manager.Application.DTOs;
using Manager.Application.Users.Commands;
using Manager.Domain.Entities;

namespace Manager.Application.Mappings
{
    public sealed class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>().ForMember(x => x.Password, y => y.Ignore()).ReverseMap();

            CreateMap<CreateUserCommand, UserDTO>();
        }
    }
}