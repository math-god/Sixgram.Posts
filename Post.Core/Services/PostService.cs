using AutoMapper;
using Post.Common.Response;
using Post.Common.Result;
using Post.Core.Dto.Post;
using Post.Core.File;
using Post.Core.Post;
using Post.Core.Token;
using Post.Database.EntityModels;
using Post.Database.Repository.Commentary;
using Post.Database.Repository.Post;

namespace Post.Core.Services;

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

        var fileId = await _fileService.Send(postCreateRequestDto.File);

        if (fileId == null)
        {
            return result;
        }

        var post = new PostModel
        {
            UserId = _tokenService.GetCurrentUserId(),
            FileId = (Guid)fileId,
            Description = postCreateRequestDto.Description
        };

        result = _mapper.Map<ResultContainer<PostResponseDto>>(await _postRepository.Create(post));

        return result;
    }

    public async Task<ResultContainer<PostResponseDto>> Delete(PostDeleteRequestDto postDeleteRequestDto)
    {
        var result = new ResultContainer<PostResponseDto>();

        var post = await _postRepository.GetById(postDeleteRequestDto.PostId);

        if (post == null)
        {
            result.ErrorType = ErrorType.BadRequest;
            return result;
        }

        result = _mapper.Map<ResultContainer<PostResponseDto>>(await _postRepository.Delete(post));

        return result;
    }

    public async Task<ResultContainer<CommentResponseDto>> CreateComment(
        CommentCreateRequestDto commentCreateRequestDto)
    {
        var result = new ResultContainer<CommentResponseDto>();

        var post = await _postRepository.GetById(commentCreateRequestDto.PostId);

        if (post == null)
        {
            result.ErrorType = ErrorType.BadRequest;
            return result;
        }

        var comment = new CommentaryModel
        {
            PostId = post.Id,
            UserId = _tokenService.GetCurrentUserId(),
            Commentary = commentCreateRequestDto.Commentary
        };

        await _commentaryRepository.Create(comment);

        post.Commentaries.Add(comment.Id);

        result = _mapper.Map<ResultContainer<CommentResponseDto>>(await _postRepository.Update(post));

        return result;
    }

    public async Task<ResultContainer<CommentResponseDto>> DeleteComment(
        CommentDeleteRequestDto commentDeleteRequestDto)
    {
        var result = new ResultContainer<CommentResponseDto>();

        var post = await _postRepository.GetById(commentDeleteRequestDto.PostId);
        var commentary = await _commentaryRepository.GetById(commentDeleteRequestDto.CommentId);

        if (post == null || commentary == null)
        {
            result.ErrorType = ErrorType.NotFound;
            return result;
        }

        await _commentaryRepository.Delete(commentary);

        post.Commentaries.Remove(commentary.Id);

        result = _mapper.Map<ResultContainer<CommentResponseDto>>(await _postRepository.Update(post));

        return result;
    }
}