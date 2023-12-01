using FastEndpoints;
using Ling.Core.Entities;
using Ling.Core.Models.Sample.Delete;
using Ling.Storage;
using IMapper = AutoMapper.IMapper;

namespace Ling.Infrastructure.Features.Sample;

internal class DeleteSampleEndpoint : Endpoint<DeleteSampleRequest>
{
    public IMapper Mapper { get; set; } = default!; // Injected by FastEndpoints automatically
    public AppDbContext DbContext { get; set; } = default!; // Injected by FastEndpoints automatically

    public override void Configure()
    {
        Delete("/api/sample/{Id:int}");
        AllowAnonymous();

        Summary(s =>
        {
            s.Summary = "删除Sample";
            s.Description = "删除一个Sample";
            s.ExampleRequest = new() { Id = 1 };
        });
    }

    public override async Task HandleAsync(DeleteSampleRequest req, CancellationToken ct)
    {
        var entity = await DbContext.FindAsync<SampleEntity>(req.Id);
        if (entity is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        DbContext.Set<SampleEntity>().Remove(entity);
        await DbContext.SaveChangesAsync(ct);

        await SendEmptyJsonObject(ct);
    }
}
