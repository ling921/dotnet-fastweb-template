namespace FastWeb.Core.Models;

public record PagedResponse<T>(long Total, IEnumerable<T> Items)
{
    public static implicit operator PagedResponse<T>((long Total, IEnumerable<T> Items) value) => new(value.Total, value.Items);
    public static implicit operator PagedResponse<T>((int Total, IEnumerable<T> Items) value) => new((long)value.Total, value.Items);
}

public static class PagedResponse
{
    public static PagedResponse<T> Create<T>(long total, IEnumerable<T> items) => (total, items);
    public static PagedResponse<T> Create<T>(int total, IEnumerable<T> items) => (total, items);
}
