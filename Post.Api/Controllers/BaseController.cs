using Microsoft.AspNetCore.Mvc;
using Post.Common.Response;
using Post.Common.Result;

namespace Post.Controllers;

public class BaseController : ControllerBase
{

    protected async Task<ActionResult> ReturnContentResult<T, TM>(Task<T> task) where T : ResultContainer<TM>
    {
        var result = await task;

        return result.HttpStatusCode switch
        {
            HttpStatusCode.Ok => Ok(result.Data),
            _ => StatusCode((int) result.HttpStatusCode)
        };
    }

    protected async Task<ActionResult> ReturnNoContentResult<T>(Task<T> task) where T : ResultContainer
    {
        var result = await task;

        return StatusCode((int) result.HttpStatusCode);
    }
}