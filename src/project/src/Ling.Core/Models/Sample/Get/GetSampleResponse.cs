namespace Ling.Core.Models.Sample.Get;

public class GetSampleResponse
{
    public int Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public DateOnly Birthday { get; set; }
}