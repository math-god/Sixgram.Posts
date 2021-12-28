﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Post.Database;

#nullable disable

namespace Post.Database.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Post.Database.EntityModels.SubscriptionModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.Property<Guid[]>("Subscribers")
                        .IsRequired()
                        .HasColumnType("uuid[]")
                        .HasColumnName("subscribers");

                    b.Property<Guid[]>("Subscriptions")
                        .IsRequired()
                        .HasColumnType("uuid[]")
                        .HasColumnName("subscriptions");

                    b.HasKey("Id");

                    b.ToTable("subscription");

                    b.HasData(
                        new
                        {
                            Id = new Guid("48c72a5c-cd56-42f6-a09b-6638efd03475"),
                            Subscribers = new Guid[0],
                            Subscriptions = new Guid[0]
                        },
                        new
                        {
                            Id = new Guid("fc829ad5-a0c4-4fef-8ac1-1c47100bc03a"),
                            Subscribers = new Guid[0],
                            Subscriptions = new Guid[0]
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
