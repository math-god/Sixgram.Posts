using Post.Common.Result;
using Post.Core.Dto.Post;

namespace Post.Core.Interfaces.Post;

public interface IPostService
{
    Task<ResultContainer> Create(PostCreateRequestDto data);
    Task<ResultContainer<PostUpdateResponseDto>> Edit(PostUpdateRequestDto data, Guid postId);
    Task<ResultContainer> Delete(Guid postId);
    Task<ResultContainer<PostModelResponseDto>> GetById(Guid postId);
    Task<ResultContainer<PostModelsResponseDto>> GetAllPostsOfCurrentUser(Guid userId);

}