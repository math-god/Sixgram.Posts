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
                .HasAnnotation("ProductVersion", "6.0.2")
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
                        .HasMaxLength(800)
                        .HasColumnType("character varying(800)")
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

            modelBuilder.Entity("Post.Database.EntityModels.LikeModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("like_id");

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

                    b.ToTable("likes");
                });

            modelBuilder.Entity("Post.Database.EntityModels.PostModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("post_id");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("day_created");

                    b.Property<Guid?>("FileId")
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
                            Id = new Guid("c378df60-efbc-4b8a-9b53-c8b42d7b0849"),
                            DateCreated = new DateTime(2022, 5, 31, 15, 9, 4, 593, DateTimeKind.Local).AddTicks(1431),
                            FileId = new Guid("e59a22ee-a6b8-445f-9c21-f7c26cac02e0"),
                            UserId = new Guid("d13d9e72-c3b8-4f33-8a1e-5048f617258e")
                        },
                        new
                        {
                            Id = new Guid("26e95359-c98d-4128-a20b-e5c2077799d7"),
                            DateCreated = new DateTime(2022, 5, 31, 15, 9, 4, 593, DateTimeKind.Local).AddTicks(1438),
                            FileId = new Guid("4b54f11d-7aa9-4331-850a-df144b412208"),
                            UserId = new Guid("b5b7990e-a4b1-45b5-a3f8-961a487e84f1")
                        });
                });

            modelBuilder.Entity("Post.Database.EntityModels.SubscriptionModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("subscription_id");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("day_created");

                    b.Property<Guid>("RespondentId")
                        .HasColumnType("uuid")
                        .HasColumnName("respondent_id");

                    b.Property<Guid>("SubscriberId")
                        .HasColumnType("uuid")
                        .HasColumnName("subscriber_id");

                    b.HasKey("Id");

                    b.ToTable("subscriptions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("7a1fb12d-9522-4377-b0b4-f980d47e6e3a"),
                            DateCreated = new DateTime(2022, 5, 31, 15, 9, 4, 593, DateTimeKind.Local).AddTicks(796),
                            RespondentId = new Guid("5188564e-b48a-4bf5-8ce6-ae02cf9f68dc"),
                            SubscriberId = new Guid("4084d4fb-5b1c-4d1f-9278-41c0e0414145")
                        },
                        new
                        {
                            Id = new Guid("8183c4de-9ae3-4425-b47d-594e7f5562e4"),
                            DateCreated = new DateTime(2022, 5, 31, 15, 9, 4, 593, DateTimeKind.Local).AddTicks(809),
                            RespondentId = new Guid("966f5664-2dad-44fd-93da-d34d171a7e57"),
                            SubscriberId = new Guid("5af274d4-f631-497f-a6c4-d8a49451dfbb")
                        });
                });

            modelBuilder.Entity("Post.Database.EntityModels.CommentaryModel", b =>
                {
                    b.HasOne("Post.Database.EntityModels.PostModel", "Post")
                        .WithMany("Commentaries")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");
                });

            modelBuilder.Entity("Post.Database.EntityModels.LikeModel", b =>
                {
                    b.HasOne("Post.Database.EntityModels.PostModel", "Post")
                        .WithMany("Likes")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");
                });

            modelBuilder.Entity("Post.Database.EntityModels.PostModel", b =>
                {
                    b.Navigation("Commentaries");

                    b.Navigation("Likes");
                });
#pragma warning restore 612, 618
        }
    }
}
