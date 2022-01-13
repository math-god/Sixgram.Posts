using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Post.Common.Response;
using Post.Common.Result;
using Post.Core.Dto.Subscription;
using Post.Core.Subscription;
using Post.Database.EntityModels;
using Post.Database.Repository.Subscription;

namespace Post.Core.Services
{
    public class SubscribeService : ISubscriptionService
    {
        /*private readonly ITokenService _tokenService;*/
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly IMapper _mapper;

        public SubscribeService
        (
            /*ITokenService tokenService,*/
            IMapper mapper,
            ISubscriptionRepository subscriptionRepository
        )
        {
            /*_tokenService = tokenService;*/
            _mapper = mapper;
            _subscriptionRepository = subscriptionRepository;
        }
        
        public async Task<ResultContainer<SubscriptionResponseDto>> Subscribe(SubscriptionRequestDto subscription)
        {
            var result = new ResultContainer<SubscriptionResponseDto>();

            var respondent = await _subscriptionRepository.GetById(subscription.RespondentId);
            var subscriber = await _subscriptionRepository.GetById(subscription.SubscriberId);

            if (respondent == null || subscriber == null)
            {
                result.ResponseCode = ResponseCode.BadRequest;
                return result;
            }

            if (respondent.Subscribers.Contains(subscription.SubscriberId))
            {
                result.ResponseCode = ResponseCode.BadRequest;
                return result;
            }

            respondent.Subscribers.Add(subscription.SubscriberId);
            subscriber.Subscriptions.Add(subscription.RespondentId);

            /*await _subscriptionRepository.Update(respondent);
            await _subscriptionRepository.Update(subscriber);*/
            
            result = _mapper.Map<ResultContainer<SubscriptionResponseDto>>(subscription);

            result.ResponseCode = ResponseCode.Success;

            return result;
        }

        public Task<ResultContainer<SubscriptionResponseDto>> Unsubscribe(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}