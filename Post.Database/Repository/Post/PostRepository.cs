using Post.Database.EntityModels;
using Post.Database.Repository.Base;

namespace Post.Database.Repository.Post;

public class PostRepository : BaseRepository<PostModel>, IPostRepository
{
    public PostRepository(AppDbContext appDbContext) : base(appDbContext)
    {
        
    }
}