using FastEndpoints;
using FluentValidation;

namespace FastWeb.Core.Models.Sample.GetList;

#if (is-project || pagination)
public class GetListSampleRequest : PagedRequest
#else
public class GetListSampleRequest
#endif
{
    [QueryParam]
    public string? Keyword { get; set; }

    public class Validator : AbstractValidator<GetListSampleRequest>
    {
        public Validator()
        {
#if (is-project || pagination)
            Include(new PagedRequestValidator());
#endif
        }
    }
}
