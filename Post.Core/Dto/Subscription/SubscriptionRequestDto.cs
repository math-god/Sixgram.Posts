namespace Post.Core.Dto.Subscription;

public class SubscriptionRequestDto
{
    public Guid RespondentId { get; set; }
    public Guid SubscriberId { get; set; }
}