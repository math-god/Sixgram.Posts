using Post.Common.Result;
using Post.Core.Dto.Comment;
using Post.Core.Dto.Post;

namespace Post.Core.Commentary;

public interface ICommentaryService
{
    Task<ResultContainer> Create(CommentCreateRequestDto commentCreateRequestDto, Guid postId);
    Task<ResultContainer> Delete(Guid commentId);
    Task<ResultContainer<CommentModelResponseDto>> GetById(Guid commentId);
}