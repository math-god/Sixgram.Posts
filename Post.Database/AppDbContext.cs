using Microsoft.EntityFrameworkCore;
using Post.Database.EntityConfigurations;
using Post.Database.EntityModels;

namespace Post.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<CommentaryModel> Commentaries { get; set; }
        public DbSet<SubscriptionModel> Subscriptions { get; set; }
        public DbSet<PostModel> Posts { get; set; }
        public DbSet<LikeModel> Likes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SubscriptionEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CommentaryEntityConfiguration());
            modelBuilder.ApplyConfiguration(new PostEntityConfiguration());
            modelBuilder.ApplyConfiguration(new LikeEntityConfiguration());
        }
    }
}