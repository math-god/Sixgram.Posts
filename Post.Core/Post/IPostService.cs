using Post.Common.Result;
using Post.Core.Dto.Post;

namespace Post.Core.Post;

public interface IPostService
{
    Task<ResultContainer<PostResponseDto>> Create(PostCreateRequestDto postCreateRequestDto);
    Task<ResultContainer<PostResponseDto>> Delete(PostDeleteRequestDto postDeleteRequestDto);
    Task<ResultContainer<CommentResponseDto>> Comment(CommentRequestDto commentRequestDto);
}