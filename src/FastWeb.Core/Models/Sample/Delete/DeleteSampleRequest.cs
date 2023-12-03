using FluentValidation;

namespace FastWeb.Core.Models.Sample.Delete;

public record DeleteSampleRequest(TEntityKey Id)
{
    public class Validator : AbstractValidator<DeleteSampleRequest>
    {
        public Validator()
        {
#if (primary-key == int || primary-key == long)
            RuleFor(x => x.Id).GreaterThan(0);
#elseif (primary-key == Guid)
            RuleFor(x => x.Id).NotEmpty();
#endif
        }
    }
}
