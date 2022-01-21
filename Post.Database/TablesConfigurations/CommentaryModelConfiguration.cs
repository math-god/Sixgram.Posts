using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Post.Database.EntityModels;

namespace Post.Database.TablesConfigurations;

public class CommentaryModelConfiguration : IEntityTypeConfiguration<CommentaryModel>
{
    public void Configure(EntityTypeBuilder<CommentaryModel> builder)
    {
        builder.Property(p => p.DateCreated)
            .HasColumnType("timestamp without time zone");
    }
}