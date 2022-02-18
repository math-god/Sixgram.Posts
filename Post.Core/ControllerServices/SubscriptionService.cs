using AutoMapper;
using Post.Common.Response;
using Post.Common.Result;
using Post.Core.Dto.Subscription;
using Post.Core.Http;
using Post.Core.Subscription;
using Post.Core.Token;
using Post.Database.EntityModels;
using Post.Database.Repository.Subscriber;

namespace Post.Core.ControllerServices
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        private readonly ISubscriptionHttpService _subscriptionHttpService;

        public SubscriptionService
        (
            IMapper mapper,
            ISubscriptionRepository subscriptionRepository,
            ITokenService tokenService,
            ISubscriptionHttpService subscriptionHttpService
        )
        {
            _subscriptionRepository = subscriptionRepository;
            _mapper = mapper;
            _tokenService = tokenService;
            _subscriptionHttpService = subscriptionHttpService;
        }

        public async Task<ResultContainer<MembershipResponseDto>> Subscribe(SubscribeRequestDto subscribe)
        {
            var result = new ResultContainer<MembershipResponseDto>();
            var currentUserId = _tokenService.GetCurrentUserId();

            var respondent = await _subscriptionHttpService.GetUser(subscribe.RespondentId);
            
            if (respondent == null)
            {
                result.ErrorType = ErrorType.NotFound;
                return result;
            }

            if (subscribe.RespondentId == currentUserId)
            {
                result.ErrorType = ErrorType.BadRequest;
                return result;
            }

            var subscriptionModel = new SubscriptionModel()
            {
                RespondentId = res
            }

            await _subscriptionRepository.Create(newSubscriber);
            await _respondentRepository.Create(newRespondent);

            return result;
        }

        public async Task<ResultContainer<MembershipResponseDto>> Unsubscribe(SubscribeRequestDto subscribe)
        {
            var result = new ResultContainer<MembershipResponseDto>();
            var currentUserId = _tokenService.GetCurrentUserId();

            var respondent = await _respondentRepository.GetById(subscribe.RespondentId);
            var subscriber = await _subscriptionRepository.GetById(currentUserId);

            if (respondent == null)
            {
                result.ErrorType = ErrorType.NotFound;
                return result;
            }

            if (respondent.Id == subscriber.Id)
            {
                result.ErrorType = ErrorType.BadRequest;
                return result;
            }

            await _subscriptionRepository.Delete(subscriber);
            await _respondentRepository.Delete(respondent);

            return result;
        }
    }
}