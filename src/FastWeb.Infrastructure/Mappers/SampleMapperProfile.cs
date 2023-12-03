using AutoMapper;
using FastWeb.Core.Entities;
using FastWeb.Core.Models.Sample.Create;
using FastWeb.Core.Models.Sample.Get;
using FastWeb.Core.Models.Sample.GetList;
using FastWeb.Core.Models.Sample.Update;

namespace FastWeb.Infrastructure.Mappers;

internal class SampleMapperProfile : Profile
{
    public SampleMapperProfile()
    {
        CreateMap<CreateSampleRequest, SampleEntity>();
        CreateMap<UpdateSampleRequest, SampleEntity>();

        CreateMap<SampleEntity, GetSampleResponse>();

#if (is-project)
        CreateProjection<SampleEntity, GetListSampleResponse>()
            .ForMember(d => d.Name, o => o.MapFrom(s => s.FirstName + " " + s.LastName));
#else
        CreateProjection<SampleEntity, GetListSampleResponse>();
#endif
    }
}
