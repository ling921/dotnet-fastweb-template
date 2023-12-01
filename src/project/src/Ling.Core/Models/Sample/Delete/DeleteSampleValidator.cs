using FluentValidation;

namespace Ling.Core.Models.Sample.Delete;

public class DeleteSampleValidator : AbstractValidator<DeleteSampleRequest>
{
    public DeleteSampleValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}
