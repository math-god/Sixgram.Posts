using Post.Common.Result;
using Post.Core.Dto.Post;
using Post.Core.Post;

namespace Post.Core.Services;

public class PostService : IPostService
{
    public async Task<ResultContainer<PostResponseDto>> Create(PostRequestDto postRequestDto)
    {
        throw new NotImplementedException();
    }

    public async Task<ResultContainer<PostResponseDto>> Delete(PostRequestDto postRequestDto)
    {
        throw new NotImplementedException();
    }
}