using AutoMapper;
using Post.Common.Response;
using Post.Common.Result;
using Post.Core.Commentary;
using Post.Core.Dto.Post;
using Post.Core.Token;
using Post.Database.EntityModels;
using Post.Database.Repository.Commentary;
using Post.Database.Repository.Post;

namespace Post.Core.Services;

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
        CommentCreateRequestDto commentCreateRequestDto)
    {
        var result = new ResultContainer<CommentResponseDto>();

        var post = await _postRepository.GetById(commentCreateRequestDto.PostId);

        if (post == null)
        {
            result.ErrorType = ErrorType.NotFound;
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

    public async Task<ResultContainer<CommentResponseDto>> Delete(
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

        if (commentary.UserId != _tokenService.GetCurrentUserId())
        {
            result.ErrorType = ErrorType.BadRequest;
            return result;
        }

        await _commentaryRepository.Delete(commentary);

        post.Commentaries.Remove(commentary.Id);

        result = _mapper.Map<ResultContainer<CommentResponseDto>>(await _postRepository.Update(post));

        return result;
    }
}