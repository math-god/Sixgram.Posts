using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Post.Common.Result;
using Post.Core.Dto.Subscription;
using Post.Core.Interfaces.Subscription;

namespace Post.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Authorize]
    [Route("api/v{version:apiVersion}/subscription")]
    public class SubscriptionController : BaseController
    {
        private readonly ISubscriptionService _subscriptionService;

        public SubscriptionController
        (
            ISubscriptionService subscriptionService
        )
        {
            _subscriptionService = subscriptionService;
        }

        /// <summary>
        ///  Gets a subscription by id
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="404">Subscription doesn't exist</response>
        [HttpGet("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [AllowAnonymous]
        public async Task<ActionResult<SubscriptionModelResponseDto>> GetById(Guid id)
            => await ReturnResult<ResultContainer<SubscriptionModelResponseDto>, SubscriptionModelResponseDto>(
                _subscriptionService.GetById(id));

        /// <summary>
        ///  Subscribes one user to another one
        /// </summary>
        /// <param name="data">Respondent Id</param>
        /// <response code="200">Success</response>
        /// <response code="400">Subscription has been already done or you are trying to subscribe to yourself</response>
        /// <response code="404">Respondent Id doesn't exist</response>
        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<SubscribeResponseDto>> Subscribe([FromForm] SubscribeRequestDto data)
            => await ReturnResult<ResultContainer<SubscribeResponseDto>, SubscribeResponseDto>(
                _subscriptionService.Subscribe(data));

        /// <summary>
        ///  Unsubscribes one user from another one
        /// </summary>
        /// <response code="204">Success</response>
        /// <response code="400">One user is not subscribed to another one</response>
        /// <response code="404">Subscription Id doesn't exist</response>
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Unsubscribe(Guid id)
            => await ReturnResult(_subscriptionService.Unsubscribe(id));
    }
}