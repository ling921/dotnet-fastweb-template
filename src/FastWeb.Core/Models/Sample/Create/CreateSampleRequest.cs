using FluentValidation;

namespace FastWeb.Core.Models.Sample.Create;

#if is-project
public record CreateSampleRequest(string FirstName, string LastName, DateOnly Birthday)
#else
public record CreateSampleRequest()
#endif
{
    public class Validator : AbstractValidator<CreateSampleRequest>
    {
        public Validator()
        {
#if is-project
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.Birthday).GreaterThanOrEqualTo(new DateOnly(1900, 1, 1));
#endif
        }
    }
}
