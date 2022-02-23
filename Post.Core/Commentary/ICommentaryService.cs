using Post.Common.Result;
using Post.Core.Dto.Post;

namespace Post.Core.Commentary;

public interface ICommentaryService
{
    Task<ResultContainer<CommentResponseDto>> Create(CommentCreateRequestDto commentCreateRequestDto, Guid postId);
    Task<ResultContainer<CommentResponseDto>> Delete(Guid commentId);
}