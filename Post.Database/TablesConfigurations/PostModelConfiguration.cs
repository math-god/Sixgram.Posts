using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Post.Database.EntityModels;

namespace Post.Database.TablesConfigurations;

public class PostModelConfiguration : IEntityTypeConfiguration<PostModel>
{
    public void Configure(EntityTypeBuilder<PostModel> builder)
    {
        builder.Property(p => p.Description)
            .HasMaxLength(2500);
        builder.Property(p => p.DateCreated)
            .HasColumnType("timestamp without time zone");
        
        builder.HasData
        (
            new PostModel()
            {
                UserId = Guid.NewGuid(),
                FileId = Guid.NewGuid(),
                Description = "Eu cum iuvaret debitis voluptatibus, esse perfecto reformidans id has."
            },
            new PostModel()
            {
                UserId = Guid.NewGuid(),
                FileId = Guid.NewGuid(),
                Description = "Tation delenit percipitur at vix. Tation delenit percipitur at vix"
            }
        );
    }
}