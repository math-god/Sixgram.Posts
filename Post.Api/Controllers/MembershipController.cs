using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Post.Common.Result;
using Post.Core.Dto.Membership;
using Post.Core.Http;
using Post.Core.Membership;
using Post.Core.Token;

namespace Post.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Authorize]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class MembershipController : BaseController
    {
        private readonly IFileHttpService _fileHttpService;
        private readonly IMembershipService _membershipService;
        private readonly ITokenService _tokenService;

        public MembershipController
        (
            IFileHttpService fileHttpService,
            IMembershipService membershipService,
            ITokenService tokenService
        )
        {
            _fileHttpService = fileHttpService;
            _membershipService = membershipService;
            _tokenService = tokenService;
        }

        /// <summary>
        ///  Subscribes one user to another one
        /// </summary>
        /// <param name="membershipRequestDto">Respondent Id</param>
        /// <response code="204">Success</response>
        /// <response code="400">Subscription has been already done or you are trying to subscribe to yourself</response>
        /// <response code="404">User Id doesn't exist</response>
        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MembershipResponseDto>> Subscribe(
            [FromForm] MembershipRequestDto membershipRequestDto)
            => await ReturnResult<ResultContainer<MembershipResponseDto>, MembershipResponseDto>
                (_membershipService.Subscribe(membershipRequestDto));
        
        /// <summary>
        ///  Unsubscribes one user from another one
        /// </summary>
        /// <param name="membershipRequestDto">Respondent Id</param>
        /// <response code="204">Success</response>
        /// <response code="400">One user is not subscribed to another one</response>
        /// <response code="404">User Id doesn't exist</response>
        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MembershipResponseDto>> Unsubscribe(
            [FromForm] MembershipRequestDto membershipRequestDto)
            => await ReturnResult<ResultContainer<MembershipResponseDto>, MembershipResponseDto>
                (_membershipService.Unsubscribe(membershipRequestDto));
        
        /// <summary>
        ///  Creates the member
        /// </summary>
        /// <response code="204">Success</response>
        /// <response code="400">The user already exists</response>
        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserDto>> CreateMember()
            => await ReturnResult<ResultContainer<UserDto>, UserDto>
                (_membershipService.CreateMember());
    }
}