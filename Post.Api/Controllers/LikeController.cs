using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Post.Core.Interfaces.Like;

namespace Post.Controllers;

[ApiVersion("1.0")]
[ApiController]
[Authorize]
[Route("api/v{version:apiVersion}/post")]
public class LikeController : BaseController
{
    private readonly ILikeService _likeService;

    public LikeController
    (
        ILikeService likeService
    )
    {
        _likeService = likeService;
    }

    /// <summary>
    ///  Likes a post
    /// </summary>
    /// <param name="id"></param>
    /// <response code="204">Success</response>
    /// <response code="400">There is no post Id in the request or like already exists</response>
    /// <response code="404">Post not found</response>
    [HttpPost("{id:guid}/like")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> LikePost(Guid id)
        => await ReturnResult(_likeService.Like(id));

    /// <summary>
    ///  Dislikes a post
    /// </summary>
    /// <param name="id"></param>
    /// <response code="204">Success</response>
    /// <response code="400">There is no like Id in the request</response>
    /// <response code="403">You don't have permission to do this</response>
    /// <response code="404">Like not found</response>
    [HttpDelete("like/{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DislikePost(Guid id)
        => await ReturnResult(_likeService.Dislike(id));
}