using System;
using Post.Core.Dto.Token;
using Post.Database.EntityModels;

namespace Post.Core.Dto.Subscription
{
    public class SubscriptionResponseDto
    {
        public List<SubscriptionModel> SubscriptionModels { get; set; }
        /*public Guid RespondentId { get; set; }
        public Guid SubscriberId { get; set; }*/
    }
}