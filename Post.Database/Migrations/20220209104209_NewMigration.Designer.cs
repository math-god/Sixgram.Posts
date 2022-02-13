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
    [Migration("20220209104209_NewMigration")]
    partial class NewMigration
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
                        .HasColumnName("member_id");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("day_created");

                    b.HasKey("Id");

                    b.ToTable("membership");

                    b.HasData(
                        new
                        {
                            Id = new Guid("05f9867a-1d44-417e-8e88-59c866ba42f8"),
                            DateCreated = new DateTime(2022, 2, 9, 13, 42, 8, 864, DateTimeKind.Local).AddTicks(1462)
                        },
                        new
                        {
                            Id = new Guid("8d5a9bda-53dc-444f-96ce-63f35fc5d732"),
                            DateCreated = new DateTime(2022, 2, 9, 13, 42, 8, 864, DateTimeKind.Local).AddTicks(1473)
                        });
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

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

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
                            Id = new Guid("a0b05ae6-29f4-44a1-9a00-578988358b31"),
                            DateCreated = new DateTime(2022, 2, 9, 13, 42, 8, 864, DateTimeKind.Local).AddTicks(2012),
                            Description = "",
                            UserId = new Guid("00000000-0000-0000-0000-000000000000")
                        });
                });

            modelBuilder.Entity("Post.Database.EntityModels.SubscriberModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("day_created");

                    b.Property<Guid>("MemberId")
                        .HasColumnType("uuid")
                        .HasColumnName("member_id");

                    b.Property<Guid>("SubscriberId")
                        .HasColumnType("uuid")
                        .HasColumnName("respondent_id");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.ToTable("subscribers");
                });

            modelBuilder.Entity("Post.Database.EntityModels.SubscriptionModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("day_created");

                    b.Property<Guid>("MemberId")
                        .HasColumnType("uuid")
                        .HasColumnName("member_id");

                    b.Property<Guid>("SubscriberId")
                        .HasColumnType("uuid")
                        .HasColumnName("subscriber_id");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.ToTable("subscriptions");
                });

            modelBuilder.Entity("Post.Database.EntityModels.CommentaryModel", b =>
                {
                    b.HasOne("Post.Database.EntityModels.PostModel", "PostModel")
                        .WithMany("CommentaryModels")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PostModel");
                });

            modelBuilder.Entity("Post.Database.EntityModels.SubscriberModel", b =>
                {
                    b.HasOne("Post.Database.EntityModels.MembershipModel", "MembershipModel")
                        .WithMany("Subscribers")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MembershipModel");
                });

            modelBuilder.Entity("Post.Database.EntityModels.SubscriptionModel", b =>
                {
                    b.HasOne("Post.Database.EntityModels.MembershipModel", "MembershipModel")
                        .WithMany("Subscriptions")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MembershipModel");
                });

            modelBuilder.Entity("Post.Database.EntityModels.MembershipModel", b =>
                {
                    b.Navigation("Subscribers");

                    b.Navigation("Subscriptions");
                });

            modelBuilder.Entity("Post.Database.EntityModels.PostModel", b =>
                {
                    b.Navigation("CommentaryModels");
                });
#pragma warning restore 612, 618
        }
    }
}