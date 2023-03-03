using Application.CQRS.Commands;
using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class DomainToDtoProfile : Profile
    {
        public DomainToDtoProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<UserDto, CreateUserCommand>().ReverseMap();
            CreateMap<UserDto, UpdateUserCommand>().ReverseMap();
        }
    }
}
