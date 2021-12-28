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

        public DbSet<SubscriptionModel> Subscriptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SubscriptionModelConfiguration());

            /*modelBuilder.Entity<SubscriptionModel>().Property(p => p.Subscribers).HasConversion<SubscriptionModel[]>();
            modelBuilder.Entity<SubscriptionModel>().Property(p => p.Subscriptions).HasConversion<SubscriptionModel[]>();*/

            modelBuilder.Entity<SubscriptionModel>().HasData
            (
                new SubscriptionModel() { },
                new SubscriptionModel() { }
            );
        }
    }
}