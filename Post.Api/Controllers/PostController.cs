using System.Net.Http.Headers;
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
    private readonly IPostService _postService;

    public PostController
    (
        IPostService postService
    )
    {
        _postService = postService;
    }

    [HttpPost]
    public StatusCodeResult Post(IFormFile file)
    {
        if (file != null && file.Length > 0)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5000/");

                byte[] data;
                using (var br = new BinaryReader(file.OpenReadStream()))
                    data = br.ReadBytes((int)file.OpenReadStream().Length);

                ByteArrayContent bytes = new ByteArrayContent(data);


                MultipartFormDataContent multiContent = new MultipartFormDataContent();

                multiContent.Add(bytes, "file", file.FileName);
                var result = client.PostAsync("api/v1/task/downloadfile", multiContent).Result;


                return
                    StatusCode((int)result
                        .StatusCode); //201 Created the request has been fulfilled, resulting in the creation of a new resource.
            }
        }

        return BadRequest();
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
    /// <param name="commentRequestDto"></param>
    /// <response code="200"></response>
    /// <response code="400"></response>
    /// <response code="404"></response>
    [HttpPost("[action]")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CommentResponseDto>> Comment([FromForm] CommentRequestDto commentRequestDto)
        => await ReturnResult<ResultContainer<CommentResponseDto>, CommentResponseDto>
            (_postService.Comment(commentRequestDto));

    /*[NonAction]
    private IActionResult StreamDownload(IFormFile iFormFile)
    {
        return new NotImplementedException();
    }*/
}