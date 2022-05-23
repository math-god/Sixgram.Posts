using Post.Common.Result;
using Post.Core.Dto.Like;

namespace Post.Core.Interfaces.Like;

public interface ILikeService
{
    Task<ResultContainer<LikeResponseDto>> Like(Guid postId);
    Task<ResultContainer> Dislike(Guid likeId);
}