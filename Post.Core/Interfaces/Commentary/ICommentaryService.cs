using Post.Common.Result;
using Post.Core.Dto.Comment;

namespace Post.Core.Interfaces.Commentary;

public interface ICommentaryService
{
    Task<ResultContainer<CommentCreateResponseDto>> Create(CommentCreateRequestDto data, Guid postId);
    Task<ResultContainer> Delete(Guid commentId);
    Task<ResultContainer<CommentModelResponseDto>> GetById(Guid commentId);
}