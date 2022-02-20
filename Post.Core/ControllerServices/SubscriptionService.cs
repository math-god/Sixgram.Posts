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

        public async Task<ResultContainer<MembershipResponseDto>> Subscribe(SubscribeRequestDto subscribeRequestDto)
        {
            var result = new ResultContainer<MembershipResponseDto>();
            var currentUserId = _tokenService.GetCurrentUserId();

            if (_subscriptionRepository.GetAllObjects().Any(item =>
                    item.RespondentId == subscribeRequestDto.RespondentId && item.SubscriberId == currentUserId))
            {
                result.ErrorType = ErrorType.BadRequest;
                return result;
            }

            if (subscribeRequestDto.RespondentId == currentUserId)
            {
                result.ErrorType = ErrorType.BadRequest;
                return result;
            }

            if (!await _subscriptionHttpService.DoesUserExist(subscribeRequestDto.RespondentId))
            {
                result.ErrorType = ErrorType.NotFound;
                return result;
            }

            var subscriptionModel = new SubscriptionModel()
            {
                RespondentId = subscribeRequestDto.RespondentId,
                SubscriberId = currentUserId
            };

            await _subscriptionRepository.Create(subscriptionModel);

            return result;
        }

        public async Task<ResultContainer<MembershipResponseDto>> Unsubscribe(SubscribeRequestDto subscribe)
        {
            var result = new ResultContainer<MembershipResponseDto>();
            var currentUserId = _tokenService.GetCurrentUserId();

            var respondent = await _subscriptionHttpService.DoesUserExist(subscribe.RespondentId);

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

            /*await _subscriptionRepository.Delete(subscriber);*/

            return result;
        }
    }
}