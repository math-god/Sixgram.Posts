using Microsoft.EntityFrameworkCore;
using Post.Database.EntityModels;

namespace Post.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
        
        public DbSet<SubscriptionModel> Subscriptions { get; set; }
        public DbSet<TestUserModel> TestUsers { get; set; }
    }
}