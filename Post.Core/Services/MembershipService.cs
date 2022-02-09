using AutoMapper;
using Post.Common.Response;
using Post.Common.Result;
using Post.Core.Dto.Membership;
using Post.Core.Membership;
using Post.Core.Token;
using Post.Database.Repository.Subscriber;
using Post.Database.Repository.Subscription;


namespace Post.Core.Services
{
    public class MembershipService : IMembershipService
    {
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly ISubscriberRepository _subscriberRepository;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;

        public MembershipService
        (
            IMapper mapper,
            ISubscriptionRepository subscriptionRepository,
            ISubscriberRepository subscriberRepository,
            ITokenService tokenService
        )
        {
            _subscriptionRepository = subscriptionRepository;
            _subscriberRepository = subscriberRepository;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        public async Task<ResultContainer<MembershipResponseDto>> Subscribe(MembershipRequestDto membership)
        {
            var result = new ResultContainer<MembershipResponseDto>();
            var currentUserId = _tokenService.GetCurrentUserId();

            var respondent = await _membershipRepository.GetById(membership.RespondentId);
            var subscriber = await _membershipRepository.GetById(currentUserId);

            if (respondent == null)
            {
                result.ErrorType = ErrorType.NotFound;
                return result;
            }

            if (respondent == subscriber || respondent.Subscribers.Contains(currentUserId))
            {
                result.ErrorType = ErrorType.BadRequest;
                return result;
            }

            respondent.Subscribers.Add(currentUserId);
            subscriber.Subscriptions.Add(membership.RespondentId);

            await _membershipRepository.Update(respondent);
            await _membershipRepository.Update(subscriber);

            return result;
        }

        public async Task<ResultContainer<MembershipResponseDto>> Unsubscribe(MembershipRequestDto membership)
        {
            var result = new ResultContainer<MembershipResponseDto>();
            var currentUserId = _tokenService.GetCurrentUserId();

            var respondent = await _membershipRepository.GetById(membership.RespondentId);
            var subscriber = await _membershipRepository.GetById(currentUserId);

            if (respondent == null)
            {
                result.ErrorType = ErrorType.NotFound;
                return result;
            }

            if (!respondent.Subscribers.Contains(currentUserId))
            {
                result.ErrorType = ErrorType.BadRequest;
                return result;
            }

            respondent.Subscribers.Remove(currentUserId);
            subscriber.Subscriptions.Remove(membership.RespondentId);

            await _membershipRepository.Update(respondent);
            await _membershipRepository.Update(subscriber);

            return result;
        }

        public async Task<ResultContainer<UserDto>> CreateMember()
        {
            var result = new ResultContainer<UserDto>();

            var userId = _tokenService.GetCurrentUserId();

            var member = new MembershipModel()
            {
                Id = userId
            };

            await _membershipRepository.Create(member);

            return result;
        }
    }
}