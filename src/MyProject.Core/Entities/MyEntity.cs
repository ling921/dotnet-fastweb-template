namespace MyProject.Core.Entities;

public class MyEntity
{
#if (entity-key-type == "string")
    public string Id { get; set; } = default!;
#elseif (entity-key-type == "int")
    public int Id { get; set; }
#elseif (entity-key-type == "long")
    public long Id { get; set; }
#elseif (entity-key-type == "guid")
    public Guid Id { get; set; }
#endif
}
