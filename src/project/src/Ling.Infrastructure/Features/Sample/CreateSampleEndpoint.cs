using FastEndpoints;
using Ling.Core.Entities;
using Ling.Core.Models.Sample.Create;
using Ling.Storage;
using IMapper = AutoMapper.IMapper;

namespace Ling.Infrastructure.Features.Sample;

internal class CreateSampleEndpoint : Endpoint<CreateSampleRequest>
{
    public IMapper Mapper { get; set; } = default!; // Injected by FastEndpoints automatically
    public AppDbContext DbContext { get; set; } = default!; // Injected by FastEndpoints automatically

    public override void Configure()
    {
        Post("api/sample");
        AllowAnonymous();

        Summary(s =>
        {
            s.Summary = "创建Sample";
            s.Description = "创建一个Sample";
            s.ExampleRequest = new() { FirstName = "Lydia", LastName = "Lawrence", Birthday = new(1999, 1, 1) };
        });
    }

    public override async Task HandleAsync(CreateSampleRequest req, CancellationToken ct)
    {
        var entity = Mapper.Map<SampleEntity>(req);
        await DbContext.AddAsync(entity, ct);
        await DbContext.SaveChangesAsync(ct);

        await SendEmptyJsonObject(ct);
    }
}
