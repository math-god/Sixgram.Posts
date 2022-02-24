using Microsoft.AspNetCore.Mvc;
using Post.Common.Response;
using Post.Common.Result;

namespace Post.Controllers;

public class BaseController : ControllerBase
{
    protected async Task<ActionResult> ReturnResult<T, TM>(Task<T> task) where T : ResultContainer<TM>
    {
        var result = await task;

        return result.HttpStatusCode switch
        {
            HttpStatusCode.Ok => Ok(result.Data),
            HttpStatusCode.NotFound => NotFound(),
            HttpStatusCode.BadRequest => BadRequest(),
            HttpStatusCode.Unauthorized => Unauthorized(),
            HttpStatusCode.ServiceUnavailable => StatusCode(503),
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    protected async Task<ActionResult> ReturnResult<T>(Task<T> task) where T : ResultContainer
    {
        var result = await task;

        return result.HttpStatusCode switch
        {
            HttpStatusCode.NoContent => NoContent(),
            HttpStatusCode.NotFound => NotFound(),
            HttpStatusCode.BadRequest => BadRequest(),
            HttpStatusCode.Unauthorized => Unauthorized(),
            HttpStatusCode.ServiceUnavailable => StatusCode(503),
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}