using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Post.Database.EntityModels;

namespace Post.Database.EntityConfigurations;

public class SubscriptionEntityConfiguration : IEntityTypeConfiguration<SubscriptionModel>
{
    public void Configure(EntityTypeBuilder<SubscriptionModel> builder)
    {
        builder.Property(p => p.DateCreated)
            .HasColumnType("timestamp without time zone");

        builder.HasData
        (
            new SubscriptionModel()
            {
                Id = Guid.NewGuid(),
                RespondentId = Guid.NewGuid(),
                SubscriberId = Guid.NewGuid(),
                DateCreated = DateTime.Now
            },
            new SubscriptionModel()
            {
                Id = Guid.NewGuid(),
                RespondentId = Guid.NewGuid(),
                SubscriberId = Guid.NewGuid(),
                DateCreated = DateTime.Now
            }
        );
    }
}