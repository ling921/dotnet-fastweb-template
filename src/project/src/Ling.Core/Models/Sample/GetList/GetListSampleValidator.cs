using FluentValidation;

namespace Ling.Core.Models.Sample.GetList;

public class GetListSampleValidator : AbstractValidator<GetListSampleRequest>
{
    public GetListSampleValidator()
    {
        Include(new PagedRequestValidator());
    }
}
