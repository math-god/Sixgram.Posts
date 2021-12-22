﻿using System;
using System.Threading.Tasks;
using Post.Common.Result;
using Post.Core.Dto;
using Post.Core.Dto.Subscription;

namespace Post.Core.Subscription
{
    public interface ISubscriptionService
    {
        Task<ResultContainer<SubscriptionResponseDto>> Subscribe(Guid userId);
        Task<ResultContainer<SubscriptionResponseDto>> Unsubscribe(Guid userId);
    }
}