using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Post.Common.Result;
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

    public PostController
    (
        IPostService postService
    )
    {
        _postService = postService;
    }

    /// <summary>
    ///  Create the post
    /// </summary>
    /// <param name="postCreateRequestDto"></param>
    /// <response code="200"></response>
    /// <response code="400"></response>
    /// <response code="404"></response>
    [HttpPost("[action]")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [RequestSizeLimit(MaxFileSize)]
    [RequestFormLimits(MultipartBodyLengthLimit = MaxFileSize)]
    public async Task<ActionResult<PostResponseDto>> Create([FromForm] PostCreateRequestDto postCreateRequestDto)
        => await ReturnResult<ResultContainer<PostResponseDto>, PostResponseDto>
            (_postService.Create(postCreateRequestDto));

    /// <summary>
    ///  Delete the post
    /// </summary>
    /// <param name="postDeleteRequestDto"></param>
    /// <response code="200"></response>
    /// <response code="400"></response>
    /// <response code="404"></response>
    [HttpDelete("[action]")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PostResponseDto>> Delete([FromForm] PostDeleteRequestDto postDeleteRequestDto)
        => await ReturnResult<ResultContainer<PostResponseDto>, PostResponseDto>
            (_postService.Delete(postDeleteRequestDto));

    /// <summary>
    ///  Comment the post
    /// </summary>
    /// <param name="commentCreateRequestDto"></param>
    /// <response code="200"></response>
    /// <response code="400"></response>
    /// <response code="404"></response>
    [HttpPost("[action]")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CommentResponseDto>> CreateComment(
        [FromForm] CommentCreateRequestDto commentCreateRequestDto)
        => await ReturnResult<ResultContainer<CommentResponseDto>, CommentResponseDto>
            (_postService.CreateComment(commentCreateRequestDto));

    /// <summary>
    ///  Delete the comment
    /// </summary>
    /// <param name="commentDeleteRequestDto"></param>
    /// <response code="200"></response>
    /// <response code="400"></response>
    /// <response code="404"></response>
    [HttpDelete("[action]")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CommentResponseDto>> DeleteComment(
        [FromForm] CommentDeleteRequestDto commentDeleteRequestDto)
        => await ReturnResult<ResultContainer<CommentResponseDto>, CommentResponseDto>
            (_postService.DeleteComment(commentDeleteRequestDto));
}