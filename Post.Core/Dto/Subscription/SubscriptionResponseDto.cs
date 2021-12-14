using System;
using Post.Core.Dto.Token;

namespace Post.Core.Dto.Subscription
{
    public class SubscriptionResponseDto
    {
        public Guid Id { get; set; }
        public TokenDto Token { get; set; }
    }
}