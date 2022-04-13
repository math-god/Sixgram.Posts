using Post.Common.Result;

namespace Post.Core.Interfaces.Like;

public interface ILikeService
{
    Task<ResultContainer> Like(Guid postId);
    Task<ResultContainer> Dislike(Guid likeId);
}