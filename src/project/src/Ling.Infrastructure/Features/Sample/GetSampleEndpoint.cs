using FastEndpoints;
using Ling.Core.Entities;
using Ling.Core.Models.Sample.Get;
using Ling.Storage;
using IMapper = AutoMapper.IMapper;

namespace Ling.Infrastructure.Features.Sample;

internal class GetSampleEndpoint : Endpoint<GetSampleRequest, GetSampleResponse>
{
    public IMapper Mapper { get; set; } = default!; // Injected by FastEndpoints automatically
    public AppDbContext DbContext { get; set; } = default!; // Injected by FastEndpoints automatically

    public override void Configure()
    {
        Get("/api/sample/{Id:int}");
        AllowAnonymous();

        Summary(s =>
        {
            s.Summary = "获取Sample";
            s.Description = "获取一个Sample";
            s.ExampleRequest = new() { Id = 1 };
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
