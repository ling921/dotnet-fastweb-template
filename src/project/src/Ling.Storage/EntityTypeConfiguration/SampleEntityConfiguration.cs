using Ling.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ling.Storage.EntityTypeConfiguration;

internal class SampleEntityConfiguration : IEntityTypeConfiguration<SampleEntity>
{
    public void Configure(EntityTypeBuilder<SampleEntity> builder)
    {
        builder.ToTable("Sample");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.FirstName).HasMaxLength(50);
        builder.Property(x => x.LastName).HasMaxLength(50);
    }
}
