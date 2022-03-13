using Post.Common.Result;
using Post.Core.Dto.Subscription;

namespace Post.Core.Interfaces.Subscription
{
    public interface ISubscriptionService
    {
        Task<ResultContainer> Subscribe(SubscribeRequestDto data);
        Task<ResultContainer> Unsubscribe(Guid subscriptionId);
        Task<ResultContainer<SubscriptionModelResponseDto>> GetById(Guid subscriptionId);
    }
}