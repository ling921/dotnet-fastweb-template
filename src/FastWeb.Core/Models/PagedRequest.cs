using FastEndpoints;
using FluentValidation;
using System.ComponentModel;

namespace FastWeb.Core.Models;

public class PagedRequest
{
    [QueryParam, DefaultValue(1)]
    public int PageNumber { get; set; } = 1;

    [QueryParam, DefaultValue(10)]
    public int PageSize { get; set; } = 10;
}

public class PagedRequestValidator : AbstractValidator<PagedRequest>
{
    public PagedRequestValidator()
    {
        RuleFor(x => x.PageNumber).GreaterThan(0);
        RuleFor(x => x.PageSize).GreaterThan(0);
    }
}
