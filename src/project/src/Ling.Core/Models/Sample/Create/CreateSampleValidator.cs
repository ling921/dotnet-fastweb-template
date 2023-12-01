using FluentValidation;

namespace Ling.Core.Models.Sample.Create;

public class CreateSampleValidator : AbstractValidator<CreateSampleRequest>
{
    public CreateSampleValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty();
        RuleFor(x => x.LastName).NotEmpty();
        RuleFor(x => x.Birthday).GreaterThanOrEqualTo(new DateOnly(1900, 1, 1));
    }
}
