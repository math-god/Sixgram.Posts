using Post.Common.Result;
using Post.Core.Dto.Subscription;

namespace Post.Core.Subscription
{
    public interface ISubscriptionService
    {
        Task<ResultContainer> Subscribe(SubscribeRequestDto subscribeRequestDto);
        Task<ResultContainer> Unsubscribe(Guid subscriptionId);
    }
}