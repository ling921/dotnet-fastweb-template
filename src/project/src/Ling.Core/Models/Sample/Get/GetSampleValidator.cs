using FluentValidation;

namespace Ling.Core.Models.Sample.Get;

public class GetSampleValidator : AbstractValidator<GetSampleRequest>
{
    public GetSampleValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}
