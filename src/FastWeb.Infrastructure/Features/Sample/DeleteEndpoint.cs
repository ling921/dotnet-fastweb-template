using FastEndpoints;
using FastWeb.Core.Entities;
using FastWeb.Core.Models.Sample.Delete;
using FastWeb.Storage;
using IMapper = AutoMapper.IMapper;

namespace FastWeb.Infrastructure.Features.Sample;

internal class DeleteEndpoint : Endpoint<DeleteSampleRequest, DeleteSampleResponse>
{
    public IMapper Mapper { get; set; } = default!; // Injected by FastEndpoints automatically
    public AppDbContext DbContext { get; set; } = default!; // Injected by FastEndpoints automatically

    public override void Configure()
    {
#if (!restful)
        Delete("api/sample/delete");
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
            s.Summary = "删除Sample";
            s.Description = "删除一个Sample";
#if (primary-key == "int" || primary-key == "long")
            s.ExampleRequest = new(1);
#elseif (primary-key == "Guid")
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

        await SendOkAsync(new(), ct);
    }
}
