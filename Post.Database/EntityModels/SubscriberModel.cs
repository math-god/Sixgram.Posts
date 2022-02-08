using System.ComponentModel.DataAnnotations.Schema;
using Post.Common.Base;

namespace Post.Database.EntityModels;

[Table("subscribers")]
public class SubscriberModel : BaseModel
{
    [Column("user_id")] 
    public override Guid Id { get; set; } = Guid.NewGuid();
    
    [Column("subscriber_id")]
    public Guid SubscriberId { get; set; }
}