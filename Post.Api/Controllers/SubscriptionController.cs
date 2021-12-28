using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Post.Core.Http;
using Post.Database;

namespace Post.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionController : BaseController
    {
        private readonly AppDbContext _appDbContext;
        private readonly IHttpService _httpService;

        public SubscriptionController
        (
            AppDbContext appDbContext,
            IHttpService httpService
        )
        {
            _appDbContext = appDbContext;
            _httpService = httpService;
        }
        
        [HttpPost("CreateSubscriptionEntity/{str}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<JsonResult> CreateSubscriptionEntity(string str)
        {
            var buffer = new byte[Request.ContentLength.Value];

            await HttpContext.Request.Body.ReadAsync(buffer, 0, buffer.Length);

            var resultString = Regex.Replace(Encoding.ASCII.GetString(buffer), @"\p{C}+", string.Empty);
            var replace = resultString.Replace("\\", string.Empty);

            return Json(replace);
        }
        
        [HttpPost("[action]/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<JsonResult> Subscribe(string userId)
        {
            throw new NotImplementedException();
        }
    }
}