using System;
using System.Collections.Generic;

namespace Post.Core.Dto.Subscription
{
    public class SubscriptionDto
    {
        public List<Guid> Subscribers { get; set; }
        public List<Guid> Subscribes { get; set; }
    }
}