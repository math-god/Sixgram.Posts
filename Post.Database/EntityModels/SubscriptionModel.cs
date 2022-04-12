using System.ComponentModel.DataAnnotations.Schema;
using Post.Common.Base;

namespace Post.Database.EntityModels;

[Table("subscriptions")]
public class SubscriptionModel : BaseModel
{
    [Column("subscription_id")]
    public override Guid Id { get; set; } 
    
    [Column("respondent_id")]
    public Guid RespondentId { get; set; }
    
    [Column("subscriber_id")]
    public Guid SubscriberId { get; set; }
}