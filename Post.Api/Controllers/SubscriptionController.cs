using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Post.Common.Result;
using Post.Core.Dto.Subscription;
using Post.Core.Http;
using Post.Core.Subscription;
using Post.Database;

namespace Post.Controllers
{
    /*[Authorize]*/
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionController : BaseController
    {
        private readonly AppDbContext _appDbContext;
        private readonly IHttpService _httpService;
        private readonly ISubscriptionService _subscriptionService;

        public SubscriptionController
        (
            AppDbContext appDbContext,
            IHttpService httpService,
            ISubscriptionService subscriptionService
        )
        {
            _appDbContext = appDbContext;
            _httpService = httpService;
            _subscriptionService = subscriptionService;
        }

        /*[HttpPost("CreateSubscriptionEntity/{str}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<JsonResult> CreateSubscriptionEntity(string str)
        {
            var buffer = new byte[Request.ContentLength.Value];

            await HttpContext.Request.Body.ReadAsync(buffer, 0, buffer.Length);

            var resultString = Regex.Replace(Encoding.ASCII.GetString(buffer), @"\p{C}+", string.Empty);
            var replace = resultString.Replace("\\", string.Empty);

            return Json(replace);
        }*/
        
        /// <summary>
        ///  Subscribe one user to another one
        /// </summary>
        /// <param name="subscription">Respondent Id and subscriber Id</param>
        /// <response code="200">Return respondent Id and subscriber Id</response>
        /// <response code="400">Subscription has been already done</response>
        /// <response code="404">User Id doesn't exist</response>
        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<SubscriptionResponseDto>> Subscribe([FromForm]SubscriptionRequestDto subscription)
            => await ReturnResult<ResultContainer<SubscriptionResponseDto>, SubscriptionResponseDto>
                (_subscriptionService.Subscribe(subscription));
        
        
        /// <summary>
        ///  Unsubscribe one user from another one
        /// </summary>
        /// <param name="subscription">Respondent Id and subscriber Id</param>
        /// <response code="200">Return respondent Id and subscriber Id</response>
        /// <response code="400">One user is not subscribed to another one</response>
        /// <response code="404">User Id doesn't exist</response>
        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<SubscriptionResponseDto>> Unsubscribe([FromForm]SubscriptionRequestDto subscription)
            => await ReturnResult<ResultContainer<SubscriptionResponseDto>, SubscriptionResponseDto>
                (_subscriptionService.Unsubscribe(subscription));
    }
}