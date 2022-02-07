using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Post.Common.Result;
using Post.Core.Commentary;
using Post.Core.Dto.Post;
using Post.Core.Post;

namespace Post.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class PostController : BaseController
{
    private const long MaxFileSize = 10L * 1024L * 1024L * 1024L;
    private readonly IPostService _postService;
    private readonly ICommentaryService _commentaryService;

    public PostController
    (
        IPostService postService,
        ICommentaryService commentaryService
    )
    {
        _postService = postService;
        _commentaryService = commentaryService;
    }

    /// <summary>
    ///  Creates the post
    /// </summary>
    /// <param name="postCreateRequestDto"></param>
    /// <response code="200">Success</response>
    /// <response code="400">There is no file in the request</response>
    [HttpPost("[action]")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [RequestSizeLimit(MaxFileSize)]
    [RequestFormLimits(MultipartBodyLengthLimit = MaxFileSize)]
    public async Task<ActionResult<PostResponseDto>> Create([FromForm] PostCreateRequestDto postCreateRequestDto)
        => await ReturnResult<ResultContainer<PostResponseDto>, PostResponseDto>
            (_postService.Create(postCreateRequestDto));

    /// <summary>
    ///  Edits the post
    /// </summary>
    /// <param name="postUpdateRequestDto"></param>
    /// <response code="200"></response>
    /// <response code="400"></response>
    /// <response code="404"></response>
    [HttpPut("[action]")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PostUpdateResponseDto>> Edit([FromForm] PostUpdateRequestDto postUpdateRequestDto)
        => await ReturnResult<ResultContainer<PostUpdateResponseDto>, PostUpdateResponseDto>
            (_postService.Edit(postUpdateRequestDto));

    /// <summary>
    ///  Deletes the post
    /// </summary>
    /// <param name="postDeleteRequestDto"></param>
    /// <response code="200">Success</response>
    /// <response code="400">There is no file Id in the request</response>
    /// <response code="404">File not found</response>
    [HttpDelete("[action]")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PostResponseDto>> Delete([FromForm] PostDeleteRequestDto postDeleteRequestDto)
        => await ReturnResult<ResultContainer<PostResponseDto>, PostResponseDto>
            (_postService.Delete(postDeleteRequestDto));

    /// <summary>
    ///  Comments the post
    /// </summary>
    /// <param name="commentCreateRequestDto"></param>
    /// <response code="200">Success</response>
    /// <response code="400">There is no post Id or commentary in the request</response>
    /// <response code="404">Post not found</response>
    [HttpPost("[action]")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CommentResponseDto>> CreateComment(
        [FromForm] CommentCreateRequestDto commentCreateRequestDto)
        => await ReturnResult<ResultContainer<CommentResponseDto>, CommentResponseDto>
            (_commentaryService.Create(commentCreateRequestDto));

    /// <summary>
    ///  Deletes the comment
    /// </summary>
    /// <param name="commentDeleteRequestDto"></param>
    /// <response code="200">Success</response>
    /// <response code="400">There is no post Id or commentary Id in the request</response>
    /// <response code="404">Post or commentary not found</response>
    [HttpDelete("[action]")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CommentResponseDto>> DeleteComment(
        [FromForm] CommentDeleteRequestDto commentDeleteRequestDto)
        => await ReturnResult<ResultContainer<CommentResponseDto>, CommentResponseDto>
            (_commentaryService.Delete(commentDeleteRequestDto));
}