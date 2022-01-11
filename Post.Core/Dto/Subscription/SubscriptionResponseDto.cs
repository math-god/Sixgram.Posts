using Post.Database.EntityModels;

namespace Post.Core.Dto.Subscription;

public class SubscriptionResponseDto
{
    public List<SubscriptionModel> Users { get; set; }
    /*public Guid RespondentId { get; set; }
    public Guid SubscriberId { get; set; }*/
}