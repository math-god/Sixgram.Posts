using Post.Common.Result;
using Post.Core.Dto.Subscription;

namespace Post.Core.Subscription
{
    public interface ISubscriptionService
    {
        Task<ResultContainer<SubscriptionResponseDto>> Subscribe(SubscriptionRequestDto subscription);
        Task<ResultContainer<SubscriptionResponseDto>> Unsubscribe(SubscriptionRequestDto subscription);
    }
}