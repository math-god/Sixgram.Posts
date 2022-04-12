using Post.Database.EntityModels;
using Post.Database.Repository.Base;

namespace Post.Database.Repository.Like;

public class LikeRepository : BaseRepository<LikeModel>, ILikeRepository
{
    public LikeRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}