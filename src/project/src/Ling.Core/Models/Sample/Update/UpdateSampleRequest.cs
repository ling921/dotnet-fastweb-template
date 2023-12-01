namespace Ling.Core.Models.Sample.Update;

public class UpdateSampleRequest
{
    public int Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public DateOnly Birthday { get; set; }
}