using AutoMapper;
using Post.Common.Response;
using Post.Common.Result;
using Post.Core.Dto.Post;
using Post.Core.Interfaces.File;
using Post.Core.Interfaces.Http;
using Post.Core.Interfaces.Post;
using Post.Core.Interfaces.User;
using Post.Database.EntityModels;
using Post.Database.Repository.Post;

namespace Post.Core.ControllerServices;

public class PostService : IPostService
{
    private readonly IPostRepository _postRepository;
    private readonly IMapper _mapper;
    private readonly IUserIdentityService _userIdentityService;
    private readonly IFileStorageService _fileStorageService;
    private readonly IUserHttpService _userHttpService;

    public PostService
    (
        IPostRepository postRepository,
        IMapper mapper,
        IUserIdentityService userIdentityService,
        IFileStorageService fileStorageService,
        IUserHttpService userHttpService
    )
    {
        _postRepository = postRepository;
        _mapper = mapper;
        _userIdentityService = userIdentityService;
        _fileStorageService = fileStorageService;
        _userHttpService = userHttpService;
    }

    public async Task<ResultContainer<PostCreateResponseDto>> Create(PostCreateRequestDto data)
    {
        var result = new ResultContainer<PostCreateResponseDto>();

        if (data?.File == null)
        {
            result.ResponseStatusCode = ResponseStatusCode.BadRequest;
            return result;
        }

        var postId = Guid.NewGuid();

        var fileId = await _fileStorageService.CreateFile(data.File, postId);

        if (fileId == null)
        {
            result.ResponseStatusCode = ResponseStatusCode.ServiceUnavailable;
            return result;
        }

        var post = new PostModel
        {
            Id = postId,
            UserId = _userIdentityService.GetCurrentUserId(),
            FileId = (Guid) fileId,
            Description = data.Description
        };

        await _postRepository.Create(post);

        result = _mapper.Map<ResultContainer<PostCreateResponseDto>>(post);

        result.ResponseStatusCode = ResponseStatusCode.Ok;
        return result;
    }

    public async Task<ResultContainer<PostUpdateResponseDto>> Edit(PostUpdateRequestDto data, Guid postId)
    {
        var result = new ResultContainer<PostUpdateResponseDto>();

        var post = await _postRepository.GetById(postId);

        if (post == null)
        {
            result.ResponseStatusCode = ResponseStatusCode.NotFound;
            return result;
        }

        if (post.UserId != _userIdentityService.GetCurrentUserId())
        {
            result.ResponseStatusCode = ResponseStatusCode.Forbidden;
            return result;
        }
        
        var fileId = await _fileStorageService.CreateFile(data.NewFile, post.Id);

        if (fileId == null)
        {
            result.ResponseStatusCode = ResponseStatusCode.ServiceUnavailable;
            return result;
        }
        
        post.FileId = fileId;
        post.Description = data.NewDescription;

        result = _mapper.Map<ResultContainer<PostUpdateResponseDto>>(await _postRepository.Update(post));

        result.ResponseStatusCode = ResponseStatusCode.Ok;
        return result;
    }

    public async Task<ResultContainer> Delete(Guid postId)
    {
        var result = new ResultContainer();

        var post = await _postRepository.GetById(postId);

        if (post == null)
        {
            result.ResponseStatusCode = ResponseStatusCode.NotFound;
            return result;
        }

        if (post.UserId != _userIdentityService.GetCurrentUserId())
        {
            result.ResponseStatusCode = ResponseStatusCode.Forbidden;
            return result;
        }

        await _postRepository.Delete(post);

        await _fileStorageService.DeleteFile((Guid) post.FileId);

        result.ResponseStatusCode = ResponseStatusCode.NoContent;
        return result;
    }

    public async Task<ResultContainer<PostModelResponseDto>> GetById(Guid postId)
    {
        var result = new ResultContainer<PostModelResponseDto>();
        var post = await _postRepository.GetById(postId);

        if (post == null)
        {
            result.ResponseStatusCode = ResponseStatusCode.NotFound;
            return result;
        }

        result = _mapper.Map<ResultContainer<PostModelResponseDto>>(post);

        result.ResponseStatusCode = ResponseStatusCode.Ok;
        return result;
    }

    public async Task<ResultContainer<PostModelsResponseDto>> GetAllPostsOfCurrentUser(Guid userId)
    {
        var result = new ResultContainer<PostModelsResponseDto>();

        var userExists = await _userHttpService.DoesUserExist(userId);

        switch (userExists)
        {
            case null:
                result.ResponseStatusCode = ResponseStatusCode.ServiceUnavailable;
                return result;
            case false:
                result.ResponseStatusCode = ResponseStatusCode.NotFound;
                return result;
        }

        var posts = await _postRepository.GetByFilter(u => u.UserId == userId);

        result = _mapper.Map<ResultContainer<PostModelsResponseDto>>(posts);

        result.ResponseStatusCode = ResponseStatusCode.Ok;
        return result;
    }
}