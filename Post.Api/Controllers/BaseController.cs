using Microsoft.AspNetCore.Mvc;
using Post.Common.Response;
using Post.Common.Result;
using Post.Core.Dto.Subscription;

namespace Post.Controllers;

public class BaseController : Controller
{
    protected async Task<ActionResult> ReturnResult<T, TM>(Task<ResultContainer<SubscriptionResponseDto>> task) where T : ResultContainer<TM>
    {
        var result = await task;

        if (result.ResponseCode.HasValue)
        {
            return result.ResponseCode switch
            {
                ResponseCode.NotFound => NotFound(),
                ResponseCode.BadRequest => BadRequest(),
                ResponseCode.Unauthorized => Unauthorized(),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        if (result.Data == null)
            return NoContent();

        return Ok(result.Data);
    }
}