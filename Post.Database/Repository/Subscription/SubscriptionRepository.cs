using System;
using System.Threading.Tasks;
using Post.Database.EntityModels;
using Post.Database.Repository.Base;

namespace Post.Database.Repository.Subscription
{
    public class SubscriptionRepository : BaseRepository<SubscriptionModel>, ISubscriptionRepository
    {
        private readonly AppDbContext _appDbContext;
        public SubscriptionRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
        
        /*public async Task<SubscriptionModel> GetByUserId(Guid userId)
            => await _appDbContext.Subscriptions.wh;*/
    }
}