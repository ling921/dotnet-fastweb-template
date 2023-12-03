using FastEndpoints;
using FastWeb.Core.Entities;
using FastWeb.Core.Models.Sample.Get;
using FastWeb.Storage;
using IMapper = AutoMapper.IMapper;

namespace FastWeb.Infrastructure.Features.Sample;

internal class GetSampleEndpoint : Endpoint<GetSampleRequest, GetSampleResponse>
{
    public IMapper Mapper { get; set; } = default!; // Injected by FastEndpoints automatically
    public AppDbContext DbContext { get; set; } = default!; // Injected by FastEndpoints automatically

    public override void Configure()
    {
#if (restful)
        Get("/api/sample/{Id:int}");
#else
        Get("/api/sample/get");
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
        var entity = await DbContext.FindAsync<SampleEntity>(req.Id);
        if (entity is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        await SendAsync(Mapper.Map<GetSampleResponse>(entity), cancellation: ct);
    }
}
