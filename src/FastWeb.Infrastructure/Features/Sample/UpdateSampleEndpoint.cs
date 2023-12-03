using FastEndpoints;
using FastWeb.Core.Entities;
using FastWeb.Core.Models.Sample.Update;
using FastWeb.Storage;
using IMapper = AutoMapper.IMapper;

namespace FastWeb.Infrastructure.Features.Sample;

internal class UpdateSampleEndpoint : Endpoint<UpdateSampleRequest, UpdateSampleResponse>
{
    public IMapper Mapper { get; set; } = default!; // Injected by FastEndpoints automatically
    public AppDbContext DbContext { get; set; } = default!; // Injected by FastEndpoints automatically

    public override void Configure()
    {
#if (restful)
        Put("/api/sample/{Id:int}");
#else
        Put("/api/sample/update");
#endif
        AllowAnonymous();

        Summary(s =>
        {
            s.Summary = "修改Sample";
            s.Description = "修改一个Sample";
#if (is-project)
            s.ExampleRequest = new(1, "Lydia", "Lawrence", new(1999, 1, 1));
#elseif (primary-key == "int" || primary-key == "long")
            s.ExampleRequest = new(1);
#elseif (primary-key == "Guid")
            s.ExampleRequest = new(Guid.NewGuid());
#else
            s.ExampleRequest = new(default!);
#endif
        });
    }

    public override async Task HandleAsync(UpdateSampleRequest req, CancellationToken ct)
    {
        var entity = await DbContext.FindAsync<SampleEntity>(req.Id);
        if (entity is null)
        {
            await SendNotFoundAsync(ct);
        }

        Mapper.Map(req, entity);
        await DbContext.SaveChangesAsync(ct);

        await SendAsync(new(), cancellation: ct);
    }
}
