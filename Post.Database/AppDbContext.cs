﻿using Microsoft.EntityFrameworkCore;
using Post.Database.EntityModels;
using Post.Database.TablesConfigurations;

namespace Post.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<MembershipModel> Membership { get; set; }
        public DbSet<PostModel> Posts { get; set; }
        public DbSet<CommentaryModel> Commentaries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MembershipModelConfiguration());
            modelBuilder.ApplyConfiguration(new CommentaryModelConfiguration());
            modelBuilder.ApplyConfiguration(new PostModelConfiguration());
        }
    }
}