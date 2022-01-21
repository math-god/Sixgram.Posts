﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Post.Database.EntityModels;

namespace Post.Database.TablesConfigurations;

public class MembershipModelConfiguration : IEntityTypeConfiguration<MembershipModel>
{
    public void Configure(EntityTypeBuilder<MembershipModel> builder)
    {
        builder
            .Property(p => p.Subscribers)
            .HasColumnType("text[]");

        builder
            .Property(p => p.Subscriptions)
            .HasColumnType("text[]");

        builder.Property(p => p.DateCreated)
            .HasColumnType("timestamp without time zone");

        builder.HasData
        (
            new MembershipModel() { },
            new MembershipModel() { }
        );
    }
}