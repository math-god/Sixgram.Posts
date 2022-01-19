using Post.Common.Result;
using Post.Core.Dto.Post;

namespace Post.Core.Post;

public interface IPostService
{
    Task<ResultContainer<PostResponseDto>> Create(PostRequestDto postRequestDto);
    Task<ResultContainer<PostResponseDto>> Delete(PostRequestDto postRequestDto);
    Task<ResultContainer<PostResponseDto>> Comment(CommentRequestDto commentRequestDto);
}