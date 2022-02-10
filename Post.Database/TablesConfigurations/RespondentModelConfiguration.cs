using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Post.Database.EntityModels;

namespace Post.Database.TablesConfigurations;

public class RespondentModelConfiguration : IEntityTypeConfiguration<RespondentModel>
{
    public void Configure(EntityTypeBuilder<RespondentModel> builder)
    {
        builder.Property(p => p.DateCreated)
            .HasColumnType("timestamp without time zone");
    }
}
    
