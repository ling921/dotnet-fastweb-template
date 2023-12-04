using FluentValidation;

namespace FastWeb.Core.Models.Sample.Update;

#if (is-project)
public record UpdateSampleRequest(TEntityKey Id, string FirstName, string LastName, DateOnly Birthday)
#else
public record UpdateSampleRequest(TEntityKey Id)
#endif
{
    public class Validator : AbstractValidator<UpdateSampleRequest>
    {
        public Validator()
        {
#if (primary-key == "int" || primary-key == "long")
            RuleFor(x => x.Id).GreaterThan(0);
#elseif (primary-key == "Guid")
            RuleFor(x => x.Id).NotEmpty();
#endif
#if (is-project)
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.Birthday).GreaterThanOrEqualTo(new DateOnly(1900, 1, 1));
#endif
        }
    }
}