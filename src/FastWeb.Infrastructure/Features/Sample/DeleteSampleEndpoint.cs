using FastEndpoints;
using FastWeb.Core.Entities;
using FastWeb.Core.Models.Sample.Delete;
using FastWeb.Storage;
using IMapper = AutoMapper.IMapper;

namespace FastWeb.Infrastructure.Features.Sample;

internal class DeleteSampleEndpoint : Endpoint<DeleteSampleRequest, DeleteSampleResponse>
{
    public IMapper Mapper { get; set; } = default!; // Injected by FastEndpoints automatically
    public AppDbContext DbContext { get; set; } = default!; // Injected by FastEndpoints automatically

    public override void Configure()
    {
#if restful
        Delete("/api/sample/{Id:int}"); 
#else
        Delete("/api/sample/delete");
#endif
        AllowAnonymous();

        Summary(s =>
        {
            s.Summary = "删除Sample";
            s.Description = "删除一个Sample";
#if (primary-key == int || primary-key == long)
            s.ExampleRequest = new(1);
#elif (primary-key == Guid)
            s.ExampleRequest = new(Guid.NewGuid());
#else
            s.ExampleRequest = new(default!);
#endif
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

        await SendAsync(new(), cancellation: ct);
    }
}
