using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Post.Database.EntityModels;

namespace Post.Database.TablesConfigurations;

public class PostModelConfiguration : IEntityTypeConfiguration<PostModel>
{
    public void Configure(EntityTypeBuilder<PostModel> builder)
    {
        builder
            .Property(p => p.Commentaries)
            .HasColumnType("text[]");

        builder.Property(p => p.DateCreated)
            .HasColumnType("timestamp without time zone");

        builder.HasData
        (
            new PostModel() { }
        );
    }
}