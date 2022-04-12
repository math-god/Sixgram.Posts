using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Post.Database.EntityModels;

namespace Post.Database.EntityConfigurations;

public class CommentaryEntityConfiguration : IEntityTypeConfiguration<CommentaryModel>
{
    public void Configure(EntityTypeBuilder<CommentaryModel> builder)
    {
        builder.Property(p => p.Commentary)
            .HasMaxLength(800);
        builder.Property(p => p.DateCreated)
            .HasColumnType("timestamp without time zone");
    }
}