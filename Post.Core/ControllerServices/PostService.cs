using AutoMapper;
using Post.Common.Response;
using Post.Common.Result;
using Post.Common.Types;
using Post.Core.Dto.Post;
using Post.Core.File;
using Post.Core.Http;
using Post.Core.Post;
using Post.Core.Token;
using Post.Database.EntityModels;
using Post.Database.Repository.Commentary;
using Post.Database.Repository.Post;

namespace Post.Core.ControllerServices;

public class PostService : IPostService
{
    private readonly IPostRepository _postRepository;
    private readonly IMapper _mapper;
    private readonly ITokenService _tokenService;
    private readonly IFileService _fileService;
    private readonly IUserHttpService _userHttpService;

    public PostService
    (
        IPostRepository postRepository,
        IMapper mapper,
        ITokenService tokenService,
        IFileService fileService,
        IUserHttpService userHttpService
    )
    {
        _postRepository = postRepository;
        _mapper = mapper;
        _tokenService = tokenService;
        _fileService = fileService;
        _userHttpService = userHttpService;
    }

    public async Task<ResultContainer> Create(PostCreateRequestDto postCreateRequestDto)
    {
        var result = new ResultContainer();

        if (postCreateRequestDto.File == null)
        {
            result.ResponseStatusCode = ResponseStatusCode.BadRequest;
            return result;
        }

        var postId = Guid.NewGuid();

        var fileId = await _fileService.Send(postCreateRequestDto.File, postId);

        if (fileId == null)
        {
            return result;
        }

        var post = new PostModel
        {
            Id = postId,
            UserId = _tokenService.GetCurrentUserId(),
            FileId = (Guid) fileId,
            Description = postCreateRequestDto.Description
        };

        await _postRepository.Create(post);

        result.ResponseStatusCode = ResponseStatusCode.NoContent;

        return result;
    }

    public async Task<ResultContainer<PostUpdateResponseDto>> Edit(PostUpdateRequestDto postUpdateRequestDto,
        Guid postId)
    {
        var result = new ResultContainer<PostUpdateResponseDto>();

        var post = await _postRepository.GetById(postId);

        if (post == null)
        {
            result.ResponseStatusCode = ResponseStatusCode.NotFound;
            return result;
        }

        if (post.UserId != _tokenService.GetCurrentUserId())
        {
            result.ResponseStatusCode = ResponseStatusCode.BadRequest;
            return result;
        }

        post.FileId = await _fileService.Send(postUpdateRequestDto.NewFile, post.Id);
        post.Description = postUpdateRequestDto.NewDescription;

        result = _mapper.Map<ResultContainer<PostUpdateResponseDto>>(await _postRepository.Update(post));

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

        if (post.UserId != _tokenService.GetCurrentUserId())
        {
            result.ResponseStatusCode = ResponseStatusCode.BadRequest;
            return result;
        }

        await _postRepository.Delete(post);
        
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

        return result;
    }

    public async Task<ResultContainer<PostModelsResponseDto>> GetAllPostsOfCurrentUser(Guid userId)
    {
        var result = new ResultContainer<PostModelsResponseDto>();

        /*var userExists = await _userHttpService.DoesUserExist(userId);
        
        switch (userExists)
        {
            case null:
                result.ResponseStatusCode = ResponseStatusCode.ServiceUnavailable;
                return result;
            case false:
                result.ResponseStatusCode = ResponseStatusCode.NotFound;
                return result;
        }*/

        result = _mapper.Map<ResultContainer<PostModelsResponseDto>>(
            _postRepository.GetByFilter(u => u.UserId == userId));

        result.ResponseStatusCode = ResponseStatusCode.Ok;
        return result;
    }
}