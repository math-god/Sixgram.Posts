﻿using AutoMapper;
using Post.Common.Error;
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

            var respondent = _subscriptionRepository.GetById(subscription.RespondentId).Result;
            var subscriber = _subscriptionRepository.GetById(subscription.SubscriberId).Result;

            if (respondent == null || subscriber == null)
            {
                result.ErrorType = ErrorType.BadRequest;
                return result;
            }

            if (respondent.Subscribers.Contains(subscription.SubscriberId))
            {
                result.ErrorType = ErrorType.BadRequest;
                return result;
            }
            
            respondent.Subscribers.Add(subscription.SubscriberId);
            subscriber.Subscriptions.Add(subscription.RespondentId);

            result = _mapper.Map<ResultContainer<SubscriptionResponseDto>>(
                await _subscriptionRepository.UpdateRange(new List<SubscriptionModel>() { respondent, subscriber }));

            return result;
        }

        public Task<ResultContainer<SubscriptionResponseDto>> Unsubscribe(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}