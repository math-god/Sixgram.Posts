using System.ComponentModel.DataAnnotations.Schema;
using Post.Common.Base;

namespace Post.Database.EntityModels;

[Table("subscription")]
public class SubscriptionModel : BaseModel
{
    [Column("id")]
    public override Guid Id { get; set; } = Guid.NewGuid();
    
    [Column("respondent_id")]
    public Guid RespondentId { get; set; }
    
    [Column("subscriber_id")]
    public Guid SubscriberId { get; set; }
}