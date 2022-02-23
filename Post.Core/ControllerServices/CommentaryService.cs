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

    public async Task<ResultContainer<CommentResponseDto>> Create(
        CommentCreateRequestDto commentCreateRequestDto, Guid postId)
    {
        var result = new ResultContainer<CommentResponseDto>();

        var post = await _postRepository.GetById(postId);

        if (post == null)
        {
            result.HttpStatusCode = HttpStatusCode.NotFound;
            return result;
        }

        var comment = new CommentaryModel
        {
            PostId = post.Id,
            UserId = _tokenService.GetCurrentUserId(),
            Commentary = commentCreateRequestDto.Commentary
        };

        await _commentaryRepository.Create(comment);

        result = _mapper.Map<ResultContainer<CommentResponseDto>>(await _postRepository.Update(post));

        return result;
    }

    public async Task<ResultContainer<CommentResponseDto>> Delete(Guid commentId)
    {
        var result = new ResultContainer<CommentResponseDto>();
        
        var commentary = await _commentaryRepository.GetById(commentId);

        if (commentary == null)
        {
            result.HttpStatusCode = HttpStatusCode.NotFound;
            return result;
        }

        if (commentary.UserId != _tokenService.GetCurrentUserId())
        {
            result.HttpStatusCode = HttpStatusCode.BadRequest;
            return result;
        }

        await _commentaryRepository.Delete(commentary);

        return result;
    }
}