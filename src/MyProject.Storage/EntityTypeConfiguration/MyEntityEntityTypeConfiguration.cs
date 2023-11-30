using MyProject.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MyProject.Storage.EntityTypeConfiguration;

internal class MyEntityEntityTypeConfiguration : IEntityTypeConfiguration<MyEntity>
{
    public void Configure(EntityTypeBuilder<MyEntity> builder)
    {
        builder.ToTable("MyEntity");
#if (has-key)

        builder.HasKey(e => e.Id);
#endif
    }
}
