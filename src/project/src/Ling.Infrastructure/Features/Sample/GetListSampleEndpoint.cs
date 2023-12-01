using AutoMapper.QueryableExtensions;
using FastEndpoints;
using Ling.Core.Entities;
using Ling.Core.Models;
using Ling.Core.Models.Sample.GetList;
using Ling.Storage;
using Microsoft.EntityFrameworkCore;
using IMapper = AutoMapper.IMapper;

namespace Ling.Infrastructure.Features.Sample;

internal class GetListSampleEndpoint : Endpoint<GetListSampleRequest, PagedResponse<GetListSampleResponse>>
{
    public IMapper Mapper { get; set; } = default!; // Injected by FastEndpoints automatically
    public AppDbContext DbContext { get; set; } = default!; // Injected by FastEndpoints automatically

    public override void Configure()
    {
        Get("/api/sample");
        AllowAnonymous();

        Summary(s =>
        {
            s.Summary = "获取Sample列表";
            s.Description = "获取Sample列表";
            s.ExampleRequest = new() { Keyword = "a" };
        });
    }

    public override async Task HandleAsync(GetListSampleRequest req, CancellationToken ct)
    {
        var result = await DbContext.Set<SampleEntity>()
            .AsNoTracking()
            .WhereIf(!string.IsNullOrWhiteSpace(req.Keyword), e => e.FirstName.Contains(req.Keyword!) || e.LastName.Contains(req.Keyword!))
            .Skip((req.PageNumber - 1) * req.PageSize)
            .Take(req.PageSize)
            .ProjectTo<GetListSampleResponse>(Mapper.ConfigurationProvider)
            .ToPagedListAsync(req, ct);

        await SendAsync(result, cancellation: ct);
    }
}
