using Post.Common.Result;
using Post.Core.Dto.Post;
using Post.Database.EntityModels;

namespace Post.Core.Post;

public interface IPostService
{
    Task<ResultContainer<PostResponseDto>> Create(PostCreateRequestDto postCreateRequestDto);
    Task<ResultContainer<PostUpdateResponseDto>> Edit(PostUpdateRequestDto postUpdateRequestDto, Guid postId);
    Task<ResultContainer<PostResponseDto>> Delete(Guid postId);
    Task<ResultContainer<PostModelResponseDto>> GetById(Guid postId);

}