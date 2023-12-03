using FastWeb.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FastWeb.Infrastructure.Extensions;

internal static class QueryableExtensions
{
    public static IQueryable<T> WhereIf<T>(
        this IQueryable<T> source,
        bool condition,
        Expression<Func<T, bool>> predicate)
    {
        return condition ? source.Where(predicate) : source;
    }

    public static IQueryable<T> WhereIf<T>(
        this IQueryable<T> source,
        bool condition,
        Expression<Func<T, bool>> truePredicate,
        Expression<Func<T, bool>> falsePredicate)
    {
        return condition ? source.Where(truePredicate) : source.Where(falsePredicate);
    }

    public static async Task<PagedResponse<T>> ToPagedListAsync<T>(
        this IQueryable<T> source,
        int pageNumber,
        int pageSize,
        CancellationToken ct = default)
    {
        var count = source.LongCount();
        var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync(ct);
        return PagedResponse.Create(count, items);
    }

    public static Task<PagedResponse<T>> ToPagedListAsync<T>(
        this IQueryable<T> source,
        PagedRequest req,
        CancellationToken ct = default)
    {
        return ToPagedListAsync(source, req.PageNumber, req.PageSize, ct);
    }
}
