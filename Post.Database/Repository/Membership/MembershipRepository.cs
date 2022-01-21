using Post.Database.EntityModels;
using Post.Database.Repository.Base;

namespace Post.Database.Repository.Membership
{
    public class MembershipRepository : BaseRepository<MembershipModel>, IMembershipRepository
    {
        public MembershipRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public override async Task<MembershipModel> Create(MembershipModel item)
        {
            /*item.DateCreated = DateTime.Now;*/
            await AppDbContext.Set<MembershipModel>().AddAsync(item);
            await AppDbContext.SaveChangesAsync();
            return item;
        }

        /*public async Task<SubscriptionModel> GetByUserId(Guid userId)
            => await _appDbContext.Subscriptions.wh;*/
       
    }
}