using Microsoft.AspNetCore.Mvc;
using Post.Common.Response;
using Post.Common.Result;

namespace Post.Controllers;

public class BaseController : Controller
{
    protected async Task<ActionResult> ReturnResult<T, TM>(Task<T> task) where T : ResultContainer<TM>
    {
        var result = await task;

        if (result.ResponseCode.HasValue)
        {
            return result.ResponseCode switch
            {
                ErrorType.NotFound => NotFound(),
                ErrorType.BadRequest => BadRequest(),
                ErrorType.Unauthorized => Unauthorized(),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        if (result.Data == null)
            return NoContent();

        return Ok(result.Data);
    }
}