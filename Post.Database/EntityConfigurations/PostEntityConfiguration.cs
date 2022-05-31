using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Post.Database.EntityModels;

namespace Post.Database.EntityConfigurations;

public class PostEntityConfiguration : IEntityTypeConfiguration<PostModel>
{
    public void Configure(EntityTypeBuilder<PostModel> builder)
    {
        builder.Property(p => p.DateCreated)
            .HasColumnType("timestamp without time zone");
        
        builder.HasData
        (
            new PostModel()
            {
                Id = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                FileId = Guid.NewGuid(),
                DateCreated = DateTime.Now
            },
            new PostModel()
            {
                Id = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                FileId = Guid.NewGuid(),
                DateCreated = DateTime.Now
            }
        );
    }
}