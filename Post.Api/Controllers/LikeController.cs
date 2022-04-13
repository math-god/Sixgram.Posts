using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Post.Core.Interfaces.Like;

namespace Post.Controllers;

[ApiVersion("1.0")]
[ApiController]
[Authorize]
[Route("api/v{version:apiVersion}")]
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
    ///  Like the post
    /// </summary>
    /// <param name="id"></param>
    /// <response code="204">Success</response>
    /// <response code="400">There is no post Id in the request</response>
    /// <response code="404">Post not found</response>
    [HttpPost("posts/{id:guid}/likes")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> LikePost(Guid id)
        => await ReturnResult(_likeService.Like(id));
}