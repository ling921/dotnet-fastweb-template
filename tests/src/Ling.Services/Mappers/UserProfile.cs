using AutoMapper;
using Ling.Shared.Entities;
using Ling.Models.UserDTO;

namespace Ling.Services.Mappers;

public class UserMapperProfile : Profile
{
    public UserMapperProfile()
    {
        CreateMap<CreateUserRequest, User>();
        CreateMap<UpdateUserRequest, User>();

        CreateMap<User, GetUserEndpoint>();
        CreateMap<User, QueryUserEndpoint>();

        CreateProjection<User, QueryUserEndpoint>();
    }
}
