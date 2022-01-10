using Microsoft.AspNetCore.Mvc;
using Post.Common.Error;
using Post.Common.Result;
using Post.Core.Dto.Subscription;

namespace Post.Controllers;

public class BaseController : Controller
{
    protected async Task<ActionResult> ReturnResult<T, TM>(Task<ResultContainer<SubscriptionResponseDto>> task) where T : ResultContainer<TM>
    {
        var result = await task;

        if (result.ErrorType.HasValue)
        {
            return result.ErrorType switch
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