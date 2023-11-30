using AutoMapper;
using MyProject.Core.Entities;
using MyProject.Core.Models.MyEntityDTO.Request;
using MyProject.Core.Models.MyEntityDTO.Response;

namespace MyProject.Infrastructure.Mappers;

public class MyEntityMapperProfile : Profile
{
    public MyEntityMapperProfile()
    {
        CreateMap<CreateMyEntityRequest, MyEntity>();
        CreateMap<UpdateMyEntityRequest, MyEntity>();

        CreateMap<MyEntity, MyEntityDetailResponse>();
        CreateMap<MyEntity, MyEntityListItemResponse>();

        CreateProjection<MyEntity, MyEntityListItemResponse>();
    }
}
