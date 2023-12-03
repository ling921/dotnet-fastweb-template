using FastEndpoints;
using FastWeb.Core.Entities;
using FastWeb.Core.Models.Sample.Create;
using FastWeb.Storage;
using IMapper = AutoMapper.IMapper;

namespace FastWeb.Infrastructure.Features.Sample;

internal class CreateSampleEndpoint : Endpoint<CreateSampleRequest, CreateSampleResponse>
{
    public IMapper Mapper { get; set; } = default!; // Injected by FastEndpoints automatically
    public AppDbContext DbContext { get; set; } = default!; // Injected by FastEndpoints automatically

    public override void Configure()
    {
#if (restful)
        Post("api/sample");
#else
        Post("api/sample/create");
#endif
        AllowAnonymous();

        Summary(s =>
        {
            s.Summary = "创建Sample";
            s.Description = "创建一个Sample";
#if (is-project)
            s.ExampleRequest = new("Lydia", "Lawrence", new(1999, 1, 1));
#else
            s.ExampleRequest = new();
#endif
        });
    }

    public override async Task HandleAsync(CreateSampleRequest req, CancellationToken ct)
    {
        var entity = Mapper.Map<SampleEntity>(req);
        await DbContext.AddAsync(entity, ct);
        await DbContext.SaveChangesAsync(ct);

        await SendAsync(new(), cancellation: ct);
    }
}
