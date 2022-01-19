using System.Data.Entity.ModelConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Post.Database.EntityModels;

namespace Post.Database.TablesConfigurations;

public class CommentaryModelConfiguration : IEntityTypeConfiguration<CommentaryModel>
{
    public void Configure(EntityTypeBuilder<CommentaryModel> builder)
    {
        builder.HasData
        (
            new CommentaryModel() { }
        );
    }
}