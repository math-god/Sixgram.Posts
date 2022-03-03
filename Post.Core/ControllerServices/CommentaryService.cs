using AutoMapper;
using Post.Common.Response;
using Post.Common.Result;
using Post.Core.Commentary;
using Post.Core.Dto.Post;
using Post.Core.Token;
using Post.Database.EntityModels;
using Post.Database.Repository.Commentary;
using Post.Database.Repository.Post;

namespace Post.Core.ControllerServices;

public class CommentaryService : ICommentaryService
{
    private readonly IPostRepository _postRepository;
    private readonly ICommentaryRepository _commentaryRepository;
    private readonly IMapper _mapper;
    private readonly ITokenService _tokenService;

    public CommentaryService
    (
        IPostRepository postRepository,
        ICommentaryRepository commentaryRepository,
        IMapper mapper,
        ITokenService tokenService
    )
    {
        _postRepository = postRepository;
        _commentaryRepository = commentaryRepository;
        _mapper = mapper;
        _tokenService = tokenService;
    }

    public async Task<ResultContainer> Create(CommentCreateRequestDto commentCreateRequestDto, Guid postId)
    {
        var result = new ResultContainer();

        var post = await _postRepository.GetById(postId);

        if (post == null)
        {
            result.ResponseStatusCode = ResponseStatusCode.NotFound;
            return result;
        }

        var comment = new CommentaryModel
        {
            PostId = post.Id,
            UserId = _tokenService.GetCurrentUserId(),
            Commentary = commentCreateRequestDto.Commentary
        };

        await _commentaryRepository.Create(comment);

        await _postRepository.Update(post);

        result.ResponseStatusCode = ResponseStatusCode.NoContent;

        return result;
    }

    public async Task<ResultContainer> Delete(Guid commentId)
    {
        var result = new ResultContainer();
        
        var commentary = await _commentaryRepository.GetById(commentId);

        if (commentary == null)
        {
            result.ResponseStatusCode = ResponseStatusCode.NotFound;
            return result;
        }

        if (commentary.UserId != _tokenService.GetCurrentUserId())
        {
            result.ResponseStatusCode = ResponseStatusCode.BadRequest;
            return result;
        }

        await _commentaryRepository.Delete(commentary);

        result.ResponseStatusCode = ResponseStatusCode.NoContent;

        return result;
    }

    public async Task<ResultContainer<CommentModelResponseDto>> GetById(Guid commentId)
    {
        var result = new ResultContainer<CommentModelResponseDto>();

        var commentary = await _commentaryRepository.GetById(commentId);

        if (commentary == null)
        {
            result.ResponseStatusCode = ResponseStatusCode.NotFound;
            return result;
        }

        result = _mapper.Map<ResultContainer<CommentModelResponseDto>>(commentary);

        result.ResponseStatusCode = ResponseStatusCode.Ok;

        return result;
    }
}