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
    public class SubscriptionController : Controller
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

        /*[HttpGet]
        public void Test()
        {
            TestUserModel testUser1 = new()
            {
                Name = "user1"
            };
            TestUserModel testUser2 = new()
            {
                Name = "user2"
            };

            _appDbContext.TestUsers.Add(testUser1);
            _appDbContext.TestUsers.Add(testUser2);

            SubscriptionModel userSubscribe1 = new()
            {
                Id = _appDbContext.TestUsers.Find(testUser1.Id).Id,
            };

            SubscriptionModel userSubscribe2 = new()
            {
                Id = _appDbContext.TestUsers.Find(testUser2.Id).Id,
            };

            _appDbContext.Subscriptions.Add(userSubscribe1);
            _appDbContext.Subscriptions.Add(userSubscribe2);

            _appDbContext.SaveChanges();

            _subscribeService.Subscribe(_applicationContext, new Guid("4781e9dc-1e7c-40fa-9e93-516dbbdf1af4"),
                new Guid("71a8d542-6242-4cf5-beba-aee32eaf2969"));
        }*/
    }
}