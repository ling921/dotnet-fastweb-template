using AutoMapper.QueryableExtensions;
using FastEndpoints;
using FastWeb.Core.Entities;
#if (is-project || pagination)
using FastWeb.Core.Models;
#endif
using FastWeb.Core.Models.Sample.GetList;
using FastWeb.Storage;
using Microsoft.EntityFrameworkCore;
using IMapper = AutoMapper.IMapper;

namespace FastWeb.Infrastructure.Features.Sample;

#if (is-project || pagination)
internal class GetListSampleEndpoint : Endpoint<GetListSampleRequest, PagedResponse<GetListSampleResponse>>
#else
internal class GetListSampleEndpoint : Endpoint<GetListSampleRequest, IEnumerable<GetListSampleResponse>>
#endif
{
    public IMapper Mapper { get; set; } = default!; // Injected by FastEndpoints automatically
    public AppDbContext DbContext { get; set; } = default!; // Injected by FastEndpoints automatically

    public override void Configure()
    {
#if (restful)
        Get("/api/sample");
#else
        Get("/api/sample/get-list");
#endif
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
#if (is-project)
            .WhereIf(!string.IsNullOrWhiteSpace(req.Keyword), e => e.FirstName.Contains(req.Keyword!) || e.LastName.Contains(req.Keyword!))
#else
            .WhereIf(!string.IsNullOrWhiteSpace(req.Keyword), e => true)
#endif
            .ProjectTo<GetListSampleResponse>(Mapper.ConfigurationProvider)
#if (is-project || pagination)
            .ToPagedListAsync(req, ct);
#else
            .ToListAsync(ct);
#endif

        await SendAsync(result, cancellation: ct);
    }
}
