using Microsoft.AspNetCore.Mvc;
using Post.Common.Result;
using Post.Core.Dto.Post;
using Post.Core.Post;

namespace Post.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PostController : BaseController
{
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
    /// <param name="postRequestDto"></param>
    /// <response code="200"></response>
    /// <response code="400"></response>
    /// <response code="404"></response>
    [HttpPost("[action]")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PostResponseDto>> Create([FromForm] PostRequestDto postRequestDto)
        => await ReturnResult<ResultContainer<PostResponseDto>, PostResponseDto>
            (_postService.Create(postRequestDto));

    /// <summary>
    ///  Delete the post
    /// </summary>
    /// <param name="postRequestDto"></param>
    /// <response code="200"></response>
    /// <response code="400"></response>
    /// <response code="404"></response>
    [HttpDelete("[action]")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PostResponseDto>> Delete([FromForm] PostRequestDto postRequestDto)
        => await ReturnResult<ResultContainer<PostResponseDto>, PostResponseDto>
            (_postService.Delete(postRequestDto));
}