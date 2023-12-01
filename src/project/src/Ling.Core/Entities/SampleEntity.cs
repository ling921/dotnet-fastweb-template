namespace Ling.Core.Entities;

public class SampleEntity
{
    public int Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public DateOnly Birthday { get; set; }
}
