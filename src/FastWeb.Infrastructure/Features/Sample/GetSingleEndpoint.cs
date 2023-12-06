using FastEndpoints;
using FastWeb.Core.Entities;
using FastWeb.Core.Models.Sample.Get;
using FastWeb.Storage;
using Microsoft.EntityFrameworkCore;
using IMapper = AutoMapper.IMapper;

namespace FastWeb.Infrastructure.Features.Sample;

internal class GetSingleEndpoint : Endpoint<GetSampleRequest, GetSampleResponse>
{
    public IMapper Mapper { get; set; } = default!; // Injected by FastEndpoints automatically
    public AppDbContext DbContext { get; set; } = default!; // Injected by FastEndpoints automatically

    public override void Configure()
    {
#if (!restful)
        Get("api/sample/get");
#elseif (primary-key == "int")
        Get("api/sample/{Id:int}");
#elseif (primary-key == "long")
        Get("api/sample/{Id:long}");
#elseif (primary-key == "Guid")
        Get("api/sample/{Id:guid}");
#else
        Get("api/sample/{Id}");
#endif
        AllowAnonymous();

        Summary(s =>
        {
            s.Summary = "获取Sample";
            s.Description = "获取一个Sample";
#if (primary-key == "int" || primary-key == "long")
            s.ExampleRequest = new(1);
#elseif (primary-key == "Guid")
            s.ExampleRequest = new(Guid.NewGuid());
#else
            s.ExampleRequest = new(default!);
#endif
        });
    }

    public override async Task HandleAsync(GetSampleRequest req, CancellationToken ct)
    {
        var entity = await DbContext.Set<SampleEntity>()
            .AsNoTracking()
            .SingleOrDefaultAsync(e => e.Id == req.Id, ct);
        if (entity is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        await SendOkAsync(Mapper.Map<GetSampleResponse>(entity), ct);
    }
}
