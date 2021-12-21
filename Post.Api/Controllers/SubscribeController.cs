using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Post.Core.Http;
using Post.Database;

namespace Post.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribeController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IHttpService _httpService;

        public SubscribeController
        (
            AppDbContext appDbContext,
            IHttpService httpService
        )
        {
            _appDbContext = appDbContext;
            _httpService = httpService;
        }

        [HttpPost("CreateSubscriptionEntity")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public void CreateSubscriptionEntity()
        {
            Console.WriteLine(HttpContext.Response.ContentType);
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