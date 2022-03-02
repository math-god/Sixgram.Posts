using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Post.Common.Result;
using Post.Core.Commentary;
using Post.Core.Dto.Post;
using Post.Core.Post;

namespace Post.Controllers;

[ApiVersion("1.0")]
[ApiController]
[Authorize]
[Route("api/v{version:apiVersion}/posts")]
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
    ///  Get the post by id
    /// </summary>
    /// <param name="id"></param>
    /// <response code="200">Success</response>
    /// <response code="404">The post not found</response>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PostModelResponseDto>> GetById(Guid id)
        => await ReturnResult<ResultContainer<PostModelResponseDto>, PostModelResponseDto>
            (_postService.GetById(id));

    /// <summary>
    ///  Creates the post
    /// </summary>
    /// <param name="uploadedFile"></param>
    /// <response code="204">Success</response>
    /// <response code="400">There is no file in the request</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [RequestSizeLimit(MaxFileSize)]
    [RequestFormLimits(MultipartBodyLengthLimit = MaxFileSize)]
    public async Task<ActionResult> Create([FromForm] PostCreateRequestDto uploadedFile)
        => await ReturnResult(_postService.Create(uploadedFile));

    /// <summary>
    ///  Edits the post
    /// </summary>
    /// <param name="postUpdateRequestDto"></param>
    /// <param name="id"></param>
    /// <response code="200">Success</response>
    /// <response code="400">Post not found</response>
    /// <response code="404">The post doesn't belong to the current user</response>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PostUpdateResponseDto>> Edit([FromForm] PostUpdateRequestDto postUpdateRequestDto,
        Guid id)
        => await ReturnResult<ResultContainer<PostUpdateResponseDto>, PostUpdateResponseDto>
            (_postService.Edit(postUpdateRequestDto, id));

    /// <summary>
    ///  Deletes the post
    /// </summary>
    /// <param name="id"></param>
    /// <response code="204">Success</response>
    /// <response code="400">The post doesn't belong to the current user</response>
    /// <response code="404">The post not found</response>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(Guid id)
        => await ReturnResult(_postService.Delete(id));
}