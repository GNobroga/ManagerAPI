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
            CreateMap<User, UserDTO>()
                .AfterMap((user, userDTO) => userDTO.Password = null)
                .ReverseMap();

            CreateMap<CreateUserCommand, UserDTO>();
            CreateMap<UpdateUserCommand, UserDTO>();
            CreateMap<LoginUserCommand, UserDTO>();
        }
    }
}