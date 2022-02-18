﻿using Post.Common.Result;
using Post.Core.Dto.Subscription;

namespace Post.Core.Subscription
{
    public interface ISubscriptionService
    {
        Task<ResultContainer<MembershipResponseDto>> Subscribe(SubscribeRequestDto subscribeRequestDto);
        Task<ResultContainer<MembershipResponseDto>> Unsubscribe(SubscribeRequestDto subscribeRequestDto);
    }
}