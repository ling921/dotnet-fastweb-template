using FastEndpoints;

namespace Ling.Core.Models.Sample.GetList;

public class GetListSampleRequest : PagedRequest
{
    [QueryParam]
    public string? Keyword { get; set; }
}
