﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Post.Database;

#nullable disable

namespace Post.Database.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220121124918_PostMigration")]
    partial class PostMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Post.Database.EntityModels.CommentaryModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("commentary_id");

                    b.Property<string>("Commentary")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("commentary");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("day_created");

                    b.Property<Guid>("PostId")
                        .HasColumnType("uuid")
                        .HasColumnName("post_id");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.ToTable("commentaries");
                });

            modelBuilder.Entity("Post.Database.EntityModels.MembershipModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("day_created");

                    b.Property<string[]>("Subscribers")
                        .IsRequired()
                        .HasColumnType("text[]")
                        .HasColumnName("subscribers");

                    b.Property<string[]>("Subscriptions")
                        .IsRequired()
                        .HasColumnType("text[]")
                        .HasColumnName("subscriptions");

                    b.HasKey("Id");

                    b.ToTable("membership");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ba2836a5-86e7-4694-bf49-2dbe12fb237e"),
                            DateCreated = new DateTime(2022, 1, 21, 15, 49, 18, 528, DateTimeKind.Local).AddTicks(4484),
                            Subscribers = new string[0],
                            Subscriptions = new string[0]
                        },
                        new
                        {
                            Id = new Guid("149c7712-3bdb-4da0-9e2d-81649b9d34ee"),
                            DateCreated = new DateTime(2022, 1, 21, 15, 49, 18, 528, DateTimeKind.Local).AddTicks(4494),
                            Subscribers = new string[0],
                            Subscriptions = new string[0]
                        });
                });

            modelBuilder.Entity("Post.Database.EntityModels.PostModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("post_id");

                    b.Property<string[]>("Commentaries")
                        .IsRequired()
                        .HasColumnType("text[]")
                        .HasColumnName("commentaries");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("day_created");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<Guid>("FileId")
                        .HasColumnType("uuid")
                        .HasColumnName("file_id");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.ToTable("posts");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e1b7c670-5957-46ef-a00d-94b2701642dc"),
                            Commentaries = new string[0],
                            DateCreated = new DateTime(2022, 1, 21, 15, 49, 18, 528, DateTimeKind.Local).AddTicks(5009),
                            Description = "",
                            FileId = new Guid("deca27d7-b0cb-44e9-b349-0c2b61bdfcf3"),
                            UserId = new Guid("00000000-0000-0000-0000-000000000000")
                        });
                });

            modelBuilder.Entity("Post.Database.EntityModels.CommentaryModel", b =>
                {
                    b.HasOne("Post.Database.EntityModels.PostModel", "PostModel")
                        .WithMany("CommentaryModel")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PostModel");
                });

            modelBuilder.Entity("Post.Database.EntityModels.PostModel", b =>
                {
                    b.Navigation("CommentaryModel");
                });
#pragma warning restore 612, 618
        }
    }
}