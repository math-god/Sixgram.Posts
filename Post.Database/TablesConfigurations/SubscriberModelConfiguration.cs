using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Post.Database.EntityModels;

namespace Post.Database.TablesConfigurations;

public class SubscriberModelConfiguration : IEntityTypeConfiguration<SubscriberModel>
{
    public void Configure(EntityTypeBuilder<SubscriberModel> builder)
    {
        builder.Property(p => p.DateCreated)
            .HasColumnType("timestamp without time zone");
    }
}