using Post.Database.EntityModels;
using Post.Database.Repository.Base;

namespace Post.Database.Repository.Subscriber;

public class SubscriptionRepository : BaseRepository<SubscriptionModel>, ISubscriptionRepository
{
    public SubscriptionRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}