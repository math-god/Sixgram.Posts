using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Post.Database.EntityModels;

namespace Post.Database.EntityConfigurations;

public class LikeEntityConfiguration : IEntityTypeConfiguration<LikeModel>
{
    public void Configure(EntityTypeBuilder<LikeModel> builder)
    {
        builder.Property(p => p.DateCreated)
            .HasColumnType("timestamp without time zone");
    }
}