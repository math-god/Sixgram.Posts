using Microsoft.AspNetCore.Mvc;
using Post.Common.Response;
using Post.Common.Result;

namespace Post.Controllers;

public class BaseController : ControllerBase
{
    protected async Task<ActionResult> ReturnResult<T, TM>(Task<T> task) where T : ResultContainer<TM>
    {
        var result = await task;

        if (result.ResponseStatusCode == null)
        {
            throw new ArgumentOutOfRangeException(nameof(result.ResponseStatusCode),
                $"Property {nameof(result.ResponseStatusCode)} can not be null");
        }

        return result.ResponseStatusCode switch
        {
            ResponseStatusCode.Ok => Ok(result.Data),
            _ => StatusCode((int)result.ResponseStatusCode)
        };
        
    }

    protected async Task<ActionResult> ReturnResult(Task<ResultContainer> task)
    {
        var result = await task;

        if (result.ResponseStatusCode == null)
        {
            throw new ArgumentOutOfRangeException(nameof(result.ResponseStatusCode),
                $"Property {nameof(result.ResponseStatusCode)} can not be null");
        }

        return StatusCode((int)result.ResponseStatusCode);
    }
}