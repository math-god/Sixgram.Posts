using System.Text;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Post.Common.Result;
using Post.Core.Dto.Membership;
using Post.Core.Http;
using Post.Core.Membership;
using Post.Core.Token;

namespace Post.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionController : BaseController
    {
        private readonly IHttpService _httpService;
        private readonly IMembershipService _membershipService;
        private readonly ITokenService _tokenService;

        public SubscriptionController
        (
            IHttpService httpService,
            IMembershipService membershipService,
            ITokenService tokenService
        )
        {
            _httpService = httpService;
            _membershipService = membershipService;
            _tokenService = tokenService;
        }

        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<JsonResult> CreateSubscriptionEntity()
        {
            Console.WriteLine(_tokenService.GetCurrentUserId());
            
            var buffer = new byte[Request.ContentLength.Value];

            await HttpContext.Request.Body.ReadAsync(buffer, 0, buffer.Length);

            var resultString = Regex.Replace(Encoding.ASCII.GetString(buffer), @"\p{C}+", string.Empty);
            var replace = resultString.Replace("\\", string.Empty);
            /*Console.WriteLine(_tokenService.GetClaim(replace, "id"));*/

            return Json(replace);
            
        }

        /// <summary>
        ///  Subscribe one user to another one
        /// </summary>
        /// <param name="membershipRequestDto">Respondent Id and subscriber Id</param>
        /// <response code="200">Return respondent Id and subscriber Id</response>
        /// <response code="400">Subscription has been already done</response>
        /// <response code="404">User Id doesn't exist</response>
        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MembershipResponseDto>> Subscribe(
            [FromForm] MembershipRequestDto membershipRequestDto)
            => await ReturnResult<ResultContainer<MembershipResponseDto>, MembershipResponseDto>
                (_membershipService.Subscribe(membershipRequestDto));


        /// <summary>
        ///  Unsubscribe one user from another one
        /// </summary>
        /// <param name="membershipRequestDto">Respondent Id and subscriber Id</param>
        /// <response code="200">Return respondent Id and subscriber Id</response>
        /// <response code="400">One user is not subscribed to another one</response>
        /// <response code="404">User Id doesn't exist</response>
        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MembershipResponseDto>> Unsubscribe(
            [FromForm] MembershipRequestDto membershipRequestDto)
            => await ReturnResult<ResultContainer<MembershipResponseDto>, MembershipResponseDto>
                (_membershipService.Unsubscribe(membershipRequestDto));
    }
}