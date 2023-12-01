using AutoMapper;
using Ling.Core.Entities;
using Ling.Core.Models.Sample.Create;
using Ling.Core.Models.Sample.Get;
using Ling.Core.Models.Sample.GetList;
using Ling.Core.Models.Sample.Update;

namespace Ling.Infrastructure.Mappers;

internal class SampleMapperProfile : Profile
{
    public SampleMapperProfile()
    {
        CreateMap<CreateSampleRequest, SampleEntity>();
        CreateMap<UpdateSampleRequest, SampleEntity>();

        CreateMap<SampleEntity, GetSampleResponse>();

        CreateProjection<SampleEntity, GetListSampleResponse>()
            .ForMember(d => d.Name, o => o.MapFrom(s => s.FirstName + " " + s.LastName));
    }
}
