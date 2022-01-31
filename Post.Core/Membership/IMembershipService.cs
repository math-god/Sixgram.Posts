using Post.Common.Result;
using Post.Core.Dto.Membership;

namespace Post.Core.Membership
{
    public interface IMembershipService
    {
        Task<ResultContainer<MembershipResponseDto>> Subscribe(MembershipRequestDto membershipRequestDto);
        Task<ResultContainer<MembershipResponseDto>> Unsubscribe(MembershipRequestDto membershipRequestDto);
        Task<ResultContainer<UserDto>> CreateMember();
    }
}