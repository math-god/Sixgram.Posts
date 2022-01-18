using Post.Common.Result;
using Post.Core.Dto.Membership;
using Post.Core.Dto.Subscription;

namespace Post.Core.Membership
{
    public interface IMembershipService
    {
        Task<ResultContainer<MembershipResponseDto>> Subscribe(MembershipRequestDto membership);
        Task<ResultContainer<MembershipResponseDto>> Unsubscribe(MembershipRequestDto membership);
    }
}