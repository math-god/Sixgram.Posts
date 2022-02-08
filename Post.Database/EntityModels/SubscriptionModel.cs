using System.ComponentModel.DataAnnotations.Schema;
using Post.Common.Base;

namespace Post.Database.EntityModels;

[Table("subscription")]
public class SubscriptionModel : BaseModel
{
    [Column("user_id")] 
    public override Guid Id { get; set; } = Guid.NewGuid();
    
    [Column("subscription_id")]
    public Guid SubscriptionId { get; set; }
}