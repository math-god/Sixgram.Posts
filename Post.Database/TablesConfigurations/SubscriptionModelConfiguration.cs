using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Post.Database.EntityModels;

namespace Post.Database.TablesConfigurations;

public class SubscriptionModelConfiguration : IEntityTypeConfiguration<SubscriptionModel>
{
    public void Configure(EntityTypeBuilder<SubscriptionModel> builder)
    {
        builder
            .Property(p => p.Subscribers)
            .HasColumnType("text[]");

        builder
            .Property(p => p.Subscriptions)
            .HasColumnType("text[]");

        builder.HasData
        (
            new SubscriptionModel() { },
            new SubscriptionModel() { }
        );
    }
}