using Post.Common.Response;
using Post.Common.Result;
using Post.Core.Interfaces.Like;
using Post.Core.Interfaces.User;
using Post.Database.EntityModels;
using Post.Database.Repository.Like;
using Post.Database.Repository.Post;

namespace Post.Core.ControllerServices;

public class LikeService : ILikeService
{
    private readonly IPostRepository _postRepository;
    private readonly ILikeRepository _likeRepository;
    private readonly IUserIdentityService _userIdentityService;

    public LikeService
    (
        IPostRepository postRepository,
        ILikeRepository likeRepository,
        IUserIdentityService userIdentityService
    )
    {
        _postRepository = postRepository;
        _likeRepository = likeRepository;
        _userIdentityService = userIdentityService;
    }

    public async Task<ResultContainer> Like(Guid postId)
    {
        var result = new ResultContainer();

        var post = await _postRepository.GetById(postId);

        if (post == null)
        {
            result.ResponseStatusCode = ResponseStatusCode.NotFound;
            return result;
        }

        var like = new LikeModel()
        {
            PostId = postId,
            UserId = _userIdentityService.GetCurrentUserId()
        };

        await _likeRepository.Create(like);

        result.ResponseStatusCode = ResponseStatusCode.NoContent;

        return result;
    }

    public Task<ResultContainer> Dislike(Guid postId)
    {
        throw new NotImplementedException();
    }
}