using Post.Common.Result;
using Post.Core.Dto.Subscription.User;

namespace Post.Core.Http;

public interface ISubscriptionHttpService
{
    Task<ResultContainer<GetUsersResponseDto>> GetUser(Guid userId);
}