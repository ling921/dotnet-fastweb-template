using AutoMapper;
using MyProject.Core.Entities;
using MyProject.Models.MyEntityDTO;

namespace MyProject.Bussiness.Mappers;

public class MyEntityMapperProfile : Profile
{
    public MyEntityMapperProfile()
    {
        CreateMap<CreateMyEntityRequest, MyEntity>();
        CreateMap<UpdateMyEntityRequest, MyEntity>();

        CreateMap<MyEntity, GetMyEntityEndpoint>();
        CreateMap<MyEntity, QueryMyEntityEndpoint>();

        CreateProjection<MyEntity, QueryMyEntityEndpoint>();
    }
}
