using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Post.Common.Result;
using Post.Core.Commentary;
using Post.Core.Dto.Comment;
using Post.Core.Dto.Post;

namespace Post.Controllers;

[ApiVersion("1.0")]
[ApiController]
[Authorize]
[Route("api/v{version:apiVersion}/posts")]
public class CommentaryController : BaseController
{
    private readonly ICommentaryService _commentaryService;

    public CommentaryController
    (
        ICommentaryService commentaryService
    )
    {
        _commentaryService = commentaryService;
    }

    /// <summary>
    ///  Gets the comment by id
    /// </summary>
    /// <param name="id"></param>
    /// <response code="200">Success</response>
    /// <response code="404">Commentary not found</response>
    [HttpGet("comments/{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CommentModelResponseDto>> GetById(Guid id)
        => await ReturnResult<ResultContainer<CommentModelResponseDto>, CommentModelResponseDto>(
            _commentaryService.GetById(id));

    /// <summary>
    ///  Comments the post
    /// </summary>
    /// <param name="commentCreateRequestDto"></param>
    /// <param name="id"></param>
    /// <response code="204">Success</response>
    /// <response code="400">There is no post Id or commentary in the request</response>
    /// <response code="404">Post not found</response>
    [HttpPost("{id:guid}/comments")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> CreateComment([FromForm] CommentCreateRequestDto commentCreateRequestDto, Guid id)
        => await ReturnResult(_commentaryService.Create(commentCreateRequestDto, id));

    /// <summary>
    ///  Deletes the comment
    /// </summary>
    /// <param name="id"></param>
    /// <response code="204">Success</response>
    /// <response code="400">There is no commentary Id in the request</response>
    /// <response code="404">Commentary not found</response>
    [HttpDelete("comments/{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteComment(Guid id)
        => await ReturnResult(_commentaryService.Delete(id));
}