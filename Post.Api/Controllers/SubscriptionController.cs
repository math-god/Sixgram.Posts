using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Post.Common.Result;
using Post.Core.Dto.Subscription;
using Post.Core.Http;
using Post.Core.Subscription;
using Post.Core.Token;

namespace Post.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Authorize]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class SubscriptionController : BaseController
    {
        private readonly IFileHttpService _fileHttpService;
        private readonly ISubscriptionService _subscriptionService;
        private readonly ITokenService _tokenService;

        public SubscriptionController
        (
            IFileHttpService fileHttpService,
            ISubscriptionService subscriptionService,
            ITokenService tokenService
        )
        {
            _fileHttpService = fileHttpService;
            _subscriptionService = subscriptionService;
            _tokenService = tokenService;
        }

        /// <summary>
        ///  Subscribes one user to another one
        /// </summary>
        /// <param name="subscribeRequestDto">Respondent Id</param>
        /// <response code="204">Success</response>
        /// <response code="400">Subscription has been already done or you are trying to subscribe to yourself</response>
        /// <response code="404">User Id doesn't exist</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MembershipResponseDto>> Subscribe(
            [FromForm] SubscribeRequestDto subscribeRequestDto)
            => await ReturnResult<ResultContainer<MembershipResponseDto>, MembershipResponseDto>
                (_subscriptionService.Subscribe(subscribeRequestDto));
        
        /// <summary>
        ///  Unsubscribes one user from another one
        /// </summary>
        /// <param name="subscribeRequestDto">Respondent Id</param>
        /// <response code="204">Success</response>
        /// <response code="400">One user is not subscribed to another one</response>
        /// <response code="404">User Id doesn't exist</response>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MembershipResponseDto>> Unsubscribe(
            [FromForm] SubscribeRequestDto subscribeRequestDto)
            => await ReturnResult<ResultContainer<MembershipResponseDto>, MembershipResponseDto>
                (_subscriptionService.Unsubscribe(subscribeRequestDto));
    }
}