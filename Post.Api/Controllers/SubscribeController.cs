using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Post.Core.Subscription;

namespace Post.Controllers
{
    [Route("subscribeController")]
    [ApiController]
    [Authorize]
    public class SubscribeController : Controller
    {
        private readonly ISubscriptionService _subscribeService;
        
        public SubscribeController(ISubscriptionService subscriptionRepository)
        {
            _subscribeService = subscriptionRepository;
        }

    }
}