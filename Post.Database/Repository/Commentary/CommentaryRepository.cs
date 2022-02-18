using Post.Database.EntityModels;
using Post.Database.Repository.Base;

namespace Post.Database.Repository.Commentary
{
    public class CommentaryRepository : BaseRepository<CommentaryModel>, ICommentaryRepository
    {
        public CommentaryRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}