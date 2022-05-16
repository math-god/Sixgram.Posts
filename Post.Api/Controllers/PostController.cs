using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Post.Common.Result;
using Post.Core.Dto.Post;
using Post.Core.Interfaces.Post;

namespace Post.Controllers;

[ApiVersion("1.0")]
[ApiController]
[Authorize]
[Route("api/v{version:apiVersion}/")]
public class PostController : BaseController
{
    private const long MaxFileSize = 2L * 1024L * 1024L * 1024L;
    private readonly IPostService _postService;


    public PostController
    (
        IPostService postService
    )
    {
        _postService = postService;
    }

    /// <summary>
    ///  Get a post by id
    /// </summary>
    /// <param name="id"></param>
    /// <response code="200">Success</response>
    /// <response code="404">The post not found</response>
    [HttpGet("post/{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [AllowAnonymous]
    public async Task<ActionResult<PostModelResponseDto>> GetById(Guid id)
        => await ReturnResult<ResultContainer<PostModelResponseDto>, PostModelResponseDto>
            (_postService.GetById(id));

    /// <summary>
    ///  Get all user's posts
    /// </summary>
    /// <param name="id"></param>
    /// <response code="200">Success</response>
    /// <response code="404">The user not found</response>
    [HttpGet("user/{id:guid}/post")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [AllowAnonymous]
    public async Task<ActionResult<PostModelsResponseDto>> GetAllPostsOfCurrentUser(Guid id)
        => await ReturnResult<ResultContainer<PostModelsResponseDto>, PostModelsResponseDto>
            (_postService.GetAllPostsOfCurrentUser(id));

    /// <summary>
    ///  Creates a post
    /// </summary>
    /// <param name="data"></param>
    /// <response code="200">Success</response>
    /// <response code="400">There is no file in the request</response>
    [HttpPost("post")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [RequestSizeLimit(MaxFileSize)]
    [RequestFormLimits(MultipartBodyLengthLimit = MaxFileSize)]
    public async Task<ActionResult<PostResponseDto>> Create([FromForm] PostCreateRequestDto data)
        => await ReturnResult<ResultContainer<PostResponseDto>, PostResponseDto>(_postService.Create(data));

    /// <summary>
    ///  Edits a post
    /// </summary>
    /// <param name="data"></param>
    /// <param name="id"></param>
    /// <response code="200">Success</response>
    /// <response code="403">The post doesn't belong to the current user</response>
    /// <response code="404">Post not found</response>
    [HttpPut("post/{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PostUpdateResponseDto>> Edit([FromForm] PostUpdateRequestDto data,
        Guid id)
        => await ReturnResult<ResultContainer<PostUpdateResponseDto>, PostUpdateResponseDto>
            (_postService.Edit(data, id));

    /// <summary>
    ///  Deletes a post
    /// </summary>
    /// <param name="id"></param>
    /// <response code="204">Success</response>
    /// <response code="403">The post doesn't belong to the current user</response>
    /// <response code="404">The post not found</response>
    [HttpDelete("post/{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(Guid id)
        => await ReturnResult(_postService.Delete(id));
}