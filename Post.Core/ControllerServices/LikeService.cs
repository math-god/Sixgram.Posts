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

        var checkLike = await _likeRepository.GetByFilter(l =>
            l.PostId == postId && l.UserId == _userIdentityService.GetCurrentUserId());

        if (checkLike.Any())
        {
            result.ResponseStatusCode = ResponseStatusCode.BadRequest;
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

    public async Task<ResultContainer> Dislike(Guid likeId)
    {
        var result = new ResultContainer();

        var like = await _likeRepository.GetById(likeId);

        if (like == null)
        {
            result.ResponseStatusCode = ResponseStatusCode.NotFound;
            return result;
        }

        if (like.UserId != _userIdentityService.GetCurrentUserId())
        {
            result.ResponseStatusCode = ResponseStatusCode.Forbidden;
            return result;
        }

        await _likeRepository.Delete(like);

        result.ResponseStatusCode = ResponseStatusCode.NoContent;

        return result;
    }
}