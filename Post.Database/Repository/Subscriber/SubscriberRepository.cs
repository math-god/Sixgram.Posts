using Post.Database.EntityModels;
using Post.Database.Repository.Base;

namespace Post.Database.Repository.Subscriber;

public class SubscriberRepository : BaseRepository<SubscriberModel>, ISubscriberRepository
{
    public SubscriberRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}