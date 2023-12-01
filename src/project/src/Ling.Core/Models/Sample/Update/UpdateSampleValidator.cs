using FluentValidation;

namespace Ling.Core.Models.Sample.Update;

public class UpdateSampleValidator : AbstractValidator<UpdateSampleRequest>
{
    public UpdateSampleValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty();
        RuleFor(x => x.LastName).NotEmpty();
        RuleFor(x => x.Birthday).GreaterThanOrEqualTo(new DateOnly(1900, 1, 1));
    }
}
