using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Post.Database.EntityModels;

namespace Post.Database.TablesConfigurations;

public class SubscriptionModelConfiguration : IEntityTypeConfiguration<SubscriptionModel>
{
    public void Configure(EntityTypeBuilder<SubscriptionModel> builder)
    {
        builder.Property(p => p.DateCreated)
            .HasColumnType("timestamp without time zone");

        builder.HasData
        (
            new SubscriptionModel()
            {
                RespondentId = Guid.NewGuid(),
                SubscriberId = Guid.NewGuid()
            },
            new SubscriptionModel()
            {
                RespondentId = Guid.NewGuid(),
                SubscriberId = Guid.NewGuid()
            }
        );
    }
}