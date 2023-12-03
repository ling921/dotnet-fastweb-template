namespace FastWeb.Core.Entities;

public class SampleEntity
{
#if (primary-key == "int" || primary-key == "long" || primary-key == "Guid")
    public TEntityKey Id { get; set; }
#else
    public TEntityKey Id { get; set; } = default!;
#endif
#if (is-project)
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public DateOnly Birthday { get; set; }
#endif
}
