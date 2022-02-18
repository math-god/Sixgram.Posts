using Microsoft.EntityFrameworkCore;
using Post.Database.EntityModels;
using Post.Database.TablesConfigurations;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SubscriptionModelConfiguration());
            modelBuilder.ApplyConfiguration(new CommentaryModelConfiguration());
            modelBuilder.ApplyConfiguration(new PostModelConfiguration());
        }
    }
}