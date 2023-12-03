namespace FastWeb.Core.Models.Sample.Get;

public class GetSampleResponse
{
    public int Id { get; set; }
#if (is-project)
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public DateOnly Birthday { get; set; }
#endif
}