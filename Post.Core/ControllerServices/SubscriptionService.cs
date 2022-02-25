using AutoMapper;
using Post.Common.Response;
using Post.Common.Result;
using Post.Core.Dto.Subscription;
using Post.Core.Http;
using Post.Core.Subscription;
using Post.Core.Token;
using Post.Database.EntityModels;
using Post.Database.Repository.Subscription;

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

        public async Task<ResultContainer> Subscribe(SubscribeRequestDto subscribeRequestDto)
        {
            var result = new ResultContainer();
            var currentUserId = _tokenService.GetCurrentUserId();

            if (_subscriptionRepository.GetByFilter(p =>
                    p.RespondentId == subscribeRequestDto.RespondentId && p.SubscriberId == currentUserId).Count() == 1)
            {
                result.HttpStatusCode = HttpStatusCode.BadRequest;
                return result;
            }
    
            if (subscribeRequestDto.RespondentId == currentUserId)
            {
                result.HttpStatusCode = HttpStatusCode.BadRequest;
                return result;
            }

            var userExists = await _subscriptionHttpService.DoesUserExist(subscribeRequestDto.RespondentId);

            switch (userExists)
            {
                case null:
                    result.HttpStatusCode = HttpStatusCode.ServiceUnavailable;
                    return result;
                case false:
                    result.HttpStatusCode = HttpStatusCode.NotFound;
                    return result;
            }

            var subscriptionModel = new SubscriptionModel()
            {
                RespondentId = subscribeRequestDto.RespondentId,
                SubscriberId = currentUserId
            };

            await _subscriptionRepository.Create(subscriptionModel);

            result.HttpStatusCode = HttpStatusCode.NoContent;

            return result;
        }

        public async Task<ResultContainer> Unsubscribe(Guid subscriptionId)
        {
            var result = new ResultContainer();
            var currentUserId = _tokenService.GetCurrentUserId();

            var subscription = await _subscriptionRepository.GetById(subscriptionId);

            if (subscription == null)
            {
                result.HttpStatusCode = HttpStatusCode.NotFound;
                return result;
            }

            await _subscriptionRepository.Delete(subscription);
            
            result.HttpStatusCode = HttpStatusCode.NoContent;

            return result;
        }
    }
}