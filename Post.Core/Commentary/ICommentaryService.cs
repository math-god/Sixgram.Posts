using Post.Common.Result;
using Post.Core.Dto.Post;

namespace Post.Core.Commentary;

public interface ICommentaryService
{
    Task<ResultContainer<CommentResponseDto>> Create(CommentCreateRequestDto commentCreateRequestDto);
    Task<ResultContainer<CommentResponseDto>> Delete(CommentDeleteRequestDto commentDeleteRequestDto);
}