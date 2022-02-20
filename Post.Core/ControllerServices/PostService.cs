using AutoMapper;
using Post.Common.Response;
using Post.Common.Result;
using Post.Common.Types;
using Post.Core.Dto.Post;
using Post.Core.File;
using Post.Core.Post;
using Post.Core.Token;
using Post.Database.EntityModels;
using Post.Database.Repository.Commentary;
using Post.Database.Repository.Post;

namespace Post.Core.ControllerServices;

public class PostService : IPostService
{
    private readonly IPostRepository _postRepository;
    private readonly ICommentaryRepository _commentaryRepository;
    private readonly IMapper _mapper;
    private readonly ITokenService _tokenService;
    private readonly IFileService _fileService;

    public PostService
    (
        IPostRepository postRepository,
        ICommentaryRepository commentaryRepository,
        IMapper mapper,
        ITokenService tokenService,
        IFileService fileService
    )
    {
        _postRepository = postRepository;
        _commentaryRepository = commentaryRepository;
        _mapper = mapper;
        _tokenService = tokenService;
        _fileService = fileService;
    }

    public async Task<ResultContainer<PostResponseDto>> Create(PostCreateRequestDto postCreateRequestDto)
    {
        var result = new ResultContainer<PostResponseDto>();

        if (postCreateRequestDto.File == null)
        {
            result.ErrorType = ErrorType.BadRequest;
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
            FileId = (Guid)fileId,
            Description = postCreateRequestDto.Description
        };

        result = _mapper.Map<ResultContainer<PostResponseDto>>(await _postRepository.Create(post));

        return result;
    }

    public async Task<ResultContainer<PostUpdateResponseDto>> Edit(PostUpdateRequestDto postUpdateRequestDto, Guid postId)
    {
        var result = new ResultContainer<PostUpdateResponseDto>();

        var post = await _postRepository.GetById(postId);

        if (post == null)
        {
            result.ErrorType = ErrorType.NotFound;
            return result;
        }

        if (post.UserId != _tokenService.GetCurrentUserId())
        {
            result.ErrorType = ErrorType.BadRequest;
            return result;
        }

        post.FileId = await _fileService.Send(postUpdateRequestDto.NewFile, post.Id);
        post.Description = postUpdateRequestDto.NewDescription;

        result = _mapper.Map<ResultContainer<PostUpdateResponseDto>>(await _postRepository.Update(post));

        return result;
    }

    public async Task<ResultContainer<PostResponseDto>> Delete(Guid postId)
    {
        var result = new ResultContainer<PostResponseDto>();

        var post = await _postRepository.GetById(postId);

        if (post == null)
        {
            result.ErrorType = ErrorType.NotFound;
            return result;
        }

        if (post.UserId != _tokenService.GetCurrentUserId())
        {
            result.ErrorType = ErrorType.BadRequest;
            return result;
        }

        result = _mapper.Map<ResultContainer<PostResponseDto>>(await _postRepository.Delete(post));

        return result;
    }

    public async Task<ResultContainer<PostModelResponseDto>> GetById(Guid postId)
    {
        var result = new ResultContainer<PostModelResponseDto>();
        var post = await _postRepository.GetById(postId);

        if (post == null)
        {
            result.ErrorType = ErrorType.NotFound;
            return result;
        }

        result = _mapper.Map<ResultContainer<PostModelResponseDto>>(post);
        
        return result;
    }
}