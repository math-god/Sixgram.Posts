using Post.Database.EntityModels;
using Post.Database.Repository.Base;

namespace Post.Database.Repository.Subscription
{
    public class SubscriptionRepository : BaseRepository<SubscriptionModel>, ISubscriptionRepository
    {
        public SubscriptionRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public override async Task<SubscriptionModel> Create(SubscriptionModel item)
        {
            /*item.DateCreated = DateTime.Now;*/
            await _appDbContext.Set<SubscriptionModel>().AddAsync(item);
            await _appDbContext.SaveChangesAsync();
            return item;
        }

        /*public async Task<SubscriptionModel> GetByUserId(Guid userId)
            => await _appDbContext.Subscriptions.wh;*/
       
    }
}