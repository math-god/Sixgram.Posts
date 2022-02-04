using Post.Common.Result;
using Post.Core.Dto.Post;

namespace Post.Core.Post;

public interface IPostService
{
    Task<ResultContainer<PostResponseDto>> Create(PostCreateRequestDto postCreateRequestDto);
    Task<ResultContainer<PostUpdateResponseDto>> Edit(PostUpdateRequestDto postUpdateRequestDto);
    Task<ResultContainer<PostResponseDto>> Delete(PostDeleteRequestDto postDeleteRequestDto);
    Task<ResultContainer<CommentResponseDto>> CreateComment(CommentCreateRequestDto commentCreateRequestDto);
    Task<ResultContainer<CommentResponseDto>> DeleteComment(CommentDeleteRequestDto commentDeleteRequestDto);
}