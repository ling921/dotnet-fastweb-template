using FastEndpoints;
using Ling.Core.Entities;
using Ling.Core.Models.Sample.Update;
using Ling.Storage;
using IMapper = AutoMapper.IMapper;

namespace Ling.Infrastructure.Features.Sample;

internal class UpdateSampleEndpoint : Endpoint<UpdateSampleRequest>
{
    public IMapper Mapper { get; set; } = default!; // Injected by FastEndpoints automatically
    public AppDbContext DbContext { get; set; } = default!; // Injected by FastEndpoints automatically

    public override void Configure()
    {
        Put("/api/sample/{Id:int}");
        AllowAnonymous();

        Summary(s =>
        {
            s.Summary = "修改Sample";
            s.Description = "修改一个Sample";
            s.ExampleRequest = new() { FirstName = "Lydia", LastName = "Lawrence", Birthday = new(1999, 1, 1) };
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

        await SendEmptyJsonObject(ct);
    }
}
