#if !restful
using FastEndpoints;
#endif
using FluentValidation;

namespace FastWeb.Core.Models.Sample.Get;

#if restful
public record GetSampleRequest(TEntityKey Id)
#else
public record GetSampleRequest([property: QueryParam] TEntityKey Id)
#endif
{
    public class Validator : AbstractValidator<GetSampleRequest>
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
