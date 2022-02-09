using System.ComponentModel.DataAnnotations.Schema;
using Post.Common.Base;

namespace Post.Database.EntityModels;

[Table("subscriptions")]
public class SubscriptionModel : BaseModel
{
    [Column("id")]
    public override Guid Id { get; set; } = Guid.NewGuid();
    
    [Column("member_id")]
    [ForeignKey("MembershipModel")]
    public Guid MemberId { get; set; }
    
    [Column("subscriber_id")]
    public  Guid SubscriberId { get; set; }
    
    public MembershipModel MembershipModel { get; set; }
}