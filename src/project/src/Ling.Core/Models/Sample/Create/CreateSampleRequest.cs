namespace Ling.Core.Models.Sample.Create;

public class CreateSampleRequest
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public DateOnly Birthday { get; set; }
}
